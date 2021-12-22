BUILDDIR ?= build

# git
LASTTAG := $(shell git tag --sort=committerdate | tail -1)

# docker option
DTAG   ?= $(LASTTAG)
DFNAME ?= Dockerfile
DRNAME ?= docker.io/aryazanov/pipeline-agent

# ------------------------------------------------------------------------------
#  init

init:
	sudo apt update
	sudo apt install jq

# ------------------------------------------------------------------------------
#  proto

.PHONY: proto
proto:
	@protoc -I ./Proto ./Proto/exec.proto \
            --csharp_out=./Proto \
            --grpc_out=./Proto \
            --plugin=protoc-gen-grpc=../../Tools/grpc_csharp_plugin.exe

# ------------------------------------------------------------------------------
#  container

.PHONY: container
container:
	@docker build -t $(DRNAME):$(DTAG) -f ./$(DFNAME) ../../.
	@docker push $(DRNAME):$(DTAG)

# ------------------------------------------------------------------------------
#  example

# make example name=echo
.PHONY: example
example:
	rm -rf ./tmp
	mkdir ./tmp
	export PIPELINE_AGENT_VERSION=$(shell jq '.examples.echo."pipeline-agent-tag"' build-meta.jsonc); \
	export COMMAND_EXECUTOR_VERSION=$(shell jq '.examples.echo."command-executor-tag"' build-meta.jsonc); \
	envsubst < ./Examples/$(name)/skaffold.yaml > ./tmp/skaffold.gen
	skaffold dev -f ./tmp/skaffold.gen --port-forward --no-prune=false --cache-artifacts=false
	rm -rf ./tmp

# make example-delete name=echo
.PHONY: example-delete
example-delete:
	@skaffold delete -f ./Examples/$(name)/skaffold.yaml