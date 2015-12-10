docker run \
       --hostname rabbitmq \
       -e RABBITMQ_ERLANG_COOKIE='hdhUii68gjsgjs68682b01OiU' \
       -v $(pwd)/src/Producer/bin/debug:/producer \
       -v $(pwd)/src/Consumer/bin/debug:/consumer \
       -ti mono /bin/bash
