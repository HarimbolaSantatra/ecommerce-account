#!/bin/bash
set -e
image="account_mcs"
container_name="account_mcs"
output_dir="out"
exposed_port=5010
container_port=8080
rm -rf $output_dir
dotnet clean
dotnet publish --output $output_dir
docker build -t $image .
docker run -itd \
    -p $exposed_port:$container_port \
    --rm \
    --name $container_name \
    --env DB_HOST="192.168.56.1" \
    $image

echo "====================="
echo "===== Container logs:"
docker logs -f $container_name
