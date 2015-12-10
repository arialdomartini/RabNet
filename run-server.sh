docker run \
       --name node1 \
       --hostname rabbitmq \
       -p 8080:15672 \
       -p 5672:5672 \
       -e RABBITMQ_ERLANG_COOKIE='hdhUii68gjsgjs68682b01OiU' \
#       -e "RABBITMQ_NODENAME=rabbitmq@myrabbit" \
       -d rabbitmq:3.5.6-management

docker run \
       --name node2 \
       --hostname rabbitmq \
       -p 8081:15672 \
       -p 5673:5672 \
       -e RABBITMQ_ERLANG_COOKIE='hdhUii68gjsgjs68682b01OiU' \
#       -e "RABBITMQ_NODENAME=rabbitmq@myrabbit" \
       -d rabbitmq:3.5.6-management


#docker run \
#       --name="rmq1" \
#       --hostname="rmq1.rabbitmq-fqdn.dev.docker" \
#       -p :5672:5672 -p :15672:15672 \
#       -e "RABBITMQ_NODENAME=rabbit@rmq1.rabbitmq-fqdn.dev.docker" \
#       -d rabbitmq:3.5.6-management
#
#docker run \
#       --name="rmq2" \
#       --hostname="rmq2.rabbitmq-fqdn.dev.docker" \
#       -p :6672:5672 -p :16672:15672 \
#       -e "RABBITMQ_NODENAME=rabbit@rmq2.rabbitmq-fqdn.dev.docker" \
#       -d rabbitmq:3.5.6-management
#
#docker run \
#       --name="rmq3" \
#       --hostname="rmq3.rabbitmq-fqdn.dev.docker" \
#       -p :7672:5672 -p :17672:15672 \
#       -e "RABBITMQ_NODENAME=rabbit@rmq3.rabbitmq-fqdn.dev.docker" \
#       -d rabbitmq:3.5.6-management

#docker attach rmq2 rabbitmqctl -n rabbit@rmq2.rabbitmq-fqdn.dev.docker stop_app
#docker attach rmq2 rabbitmqctl -n rabbit@rmq2.rabbitmq-fqdn.dev.docker join_cluster rabbit@rmq1.rabbitmq-fqdn.dev.docker
#docker attach rmq2 rabbitmqctl -n rabbit@rmq2.rabbitmq-fqdn.dev.docker start_app
#
#docker attach rmq3 rabbitmqctl -n rabbit@rmq3.rabbitmq-fqdn.dev.docker stop_app
#docker attach rmq3 rabbitmqctl -n rabbit@rmq3.rabbitmq-fqdn.dev.docker join_cluster rabbit@rmq1.rabbitmq-fqdn.dev.docker
#docker attach rmq3 rabbitmqctl -n rabbit@rmq3.rabbitmq-fqdn.dev.docker start_app
