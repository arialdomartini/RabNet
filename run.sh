docker run \
       --hostname rabbitmq \
       -v $(pwd)/src/Producer/bin/debug:/producer \
       -v $(pwd)/src/Consumer/bin/debug:/consumer \
       -ti mono /bin/bash
