docker run \
       --hostname rabbitmq \
       -p 8080:15672 \
       -p 5672:5672 \
       -d rabbitmq:3.5.6-management
