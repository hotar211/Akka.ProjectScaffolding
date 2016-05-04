﻿using System;
using Akka.Actor;
using Akka.Cluster.Utility;
using Domain.Interface;

namespace GameServer.Tests
{
    public class ClusterContextFixture : IDisposable
    {
        public ClusterNodeContext Context { get; private set; }

        public ClusterContextFixture()
        {
            // force interface assembly to be loaded before creating ProtobufSerializer

            var type = typeof(IUser);
            if (type == null)
                throw new InvalidProgramException("!");
        }

        public void Initialize(ActorSystem system)
        {
            var context = new ClusterNodeContext { System = system };

            context.ClusterActorDiscovery = system.ActorOf(Props.Create(
                () => new ClusterActorDiscovery(null)));

            context.UserTable = system.ActorOf(Props.Create(
                () => new DistributedActorTable<long>(
                          "User", context.ClusterActorDiscovery, null, null)));

            context.UserTableContainer = system.ActorOf(Props.Create(
                () => new DistributedActorTableContainer<long>(
                          "User", context.ClusterActorDiscovery, null, null)));

            Context = context;
        }

        public void Dispose()
        {
            if (Context == null)
                return;

            Context.System.Terminate();
            Context = null;
        }
    }
}