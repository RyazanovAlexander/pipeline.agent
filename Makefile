BUILDDIR ?= build

# git
LASTTAG := $(shell git tag --sort=committerdate | tail -1)

# docker option
DTAG   ?= $(LASTTAG)
DFNAME ?= Dockerfile
DRNAME ?= docker.io/aryazanov/pipeline-agent

# example
TMPFOLDER ?= ./src/tmp

# ------------------------------------------------------------------------------
#  init

init:
	sudo apt update
	sudo apt install jq

# ------------------------------------------------------------------------------
#  proto

.PHONY: proto
proto:
	@protoc -I .src/Proto .src/Proto/exec.proto \
            --csharp_out=./src/Proto \
            --grpc_out=./src/Proto \
            --plugin=protoc-gen-grpc=./tools/grpc_csharp_plugin.exe

# ------------------------------------------------------------------------------
#  container

.PHONY: container
container:
	@docker build -t $(DRNAME):$(DTAG) -f ./src/$(DFNAME) .
	@docker push $(DRNAME):$(DTAG)

# ------------------------------------------------------------------------------
#  example

# make example name=echo
.PHONY: example
example:
	rm -rf $(TMPFOLDER)
	mkdir $(TMPFOLDER)
	export PIPELINE_AGENT_VERSION=$(shell jq '.examples.echo."pipeline-agent-tag"' src/build-meta.jsonc); \
	export COMMAND_EXECUTOR_VERSION=$(shell jq '.examples.echo."command-executor-tag"' src/build-meta.jsonc); \
	envsubst < ./src/Examples/$(name)/skaffold.yaml > $(TMPFOLDER)/skaffold.gen
	skaffold dev -f $(TMPFOLDER)/skaffold.gen --port-forward --no-prune=false --cache-artifacts=false

# make example-delete name=echo
.PHONY: example-delete
example-delete:
	@skaffold delete -f ./src/Examples/$(name)/skaffold.yaml
	rm -rf $(TMPFOLDER)