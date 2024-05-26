FROM mcr.microsoft.com/dotnet/sdk:8.0

ARG USERNAME=app
ARG USER_UID=1000
ARG USER_GID=${USER_UID}

RUN groupmod --gid $USER_GID $USERNAME \
    && usermod --uid $USER_UID --gid $USER_GID $USERNAME --shell /bin/bash

CMD ["tail", "-f", "/dev/null"]
USER $USERNAME
