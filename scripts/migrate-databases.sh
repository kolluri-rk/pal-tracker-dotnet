#!/usr/bin/env bash
set -e


app_guid=`cf app $1 --guid`
credentials=`cf curl /v2/apps/$app_guid/env | jq '.system_env_json.VCAP_SERVICES' | jq '.["p-mysql"][0].credentials'`

ip_address=`echo $credentials | jq -r '.hostname'`
db_name=`echo $credentials | jq -r '.name'`
db_username=`echo $credentials | jq -r '.username'`
db_password=`echo $credentials | jq -r '.password'`

# echo "chek ssh enabled on spcace review"
# cf space-ssh-allowed review

# echo "chek ssh enabled on app $1"
# cf ssh-enabled $1

# echo "sshing to app $1"
# cf ssh $1

# cf ssh on PCF One is failing on 1st atempt, but going through on 2nd attempt. so made this change
echo "Opening ssh tunnel to $ip_address using app $1 - 1st time"
cf ssh -N -L 63306:$ip_address:3306 $1 || true

echo "Opening ssh tunnel to $ip_address using app $1 - 2nd time"
cf ssh -N -L 63306:$ip_address:3306 $1 &
cf_ssh_pid=$!

echo "Waiting for tunnel"
sleep 5

# Passing this in as a param is a bit strage. Maybe put flyway on the path?
$3/flyway-*/flyway -url="jdbc:mysql://127.0.0.1:63306/$db_name" -locations=filesystem:$2/databases/tracker -user=$db_username -password=$db_password migrate

kill -STOP $cf_ssh_pid
