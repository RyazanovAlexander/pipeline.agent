ARG COMMAND_EXECUTOR_VERSION=latest
FROM docker.io/aryazanov/command-executor:${COMMAND_EXECUTOR_VERSION} AS command-executor

FROM alpine:3.13.5
WORKDIR /
COPY --from=command-executor /bin/command-executor /bin/command-executor

USER 65535:65535
ENTRYPOINT ["command-executor"]