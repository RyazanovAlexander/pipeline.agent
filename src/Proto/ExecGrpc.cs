// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: exec.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Exec {
  public static partial class ExecService
  {
    static readonly string __ServiceName = "exec.ExecService";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::Exec.ExecCommands> __Marshaller_exec_ExecCommands = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Exec.ExecCommands.Parser));
    static readonly grpc::Marshaller<global::Exec.ExecResult> __Marshaller_exec_ExecResult = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Exec.ExecResult.Parser));

    static readonly grpc::Method<global::Exec.ExecCommands, global::Exec.ExecResult> __Method_ExecuteCommands = new grpc::Method<global::Exec.ExecCommands, global::Exec.ExecResult>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ExecuteCommands",
        __Marshaller_exec_ExecCommands,
        __Marshaller_exec_ExecResult);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Exec.ExecReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ExecService</summary>
    [grpc::BindServiceMethod(typeof(ExecService), "BindService")]
    public abstract partial class ExecServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Exec.ExecResult> ExecuteCommands(global::Exec.ExecCommands request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for ExecService</summary>
    public partial class ExecServiceClient : grpc::ClientBase<ExecServiceClient>
    {
      /// <summary>Creates a new client for ExecService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public ExecServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for ExecService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public ExecServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected ExecServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected ExecServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Exec.ExecResult ExecuteCommands(global::Exec.ExecCommands request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ExecuteCommands(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Exec.ExecResult ExecuteCommands(global::Exec.ExecCommands request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_ExecuteCommands, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Exec.ExecResult> ExecuteCommandsAsync(global::Exec.ExecCommands request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ExecuteCommandsAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Exec.ExecResult> ExecuteCommandsAsync(global::Exec.ExecCommands request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_ExecuteCommands, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override ExecServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ExecServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(ExecServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_ExecuteCommands, serviceImpl.ExecuteCommands).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ExecServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_ExecuteCommands, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Exec.ExecCommands, global::Exec.ExecResult>(serviceImpl.ExecuteCommands));
    }

  }
}
#endregion
