﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Akka.Interfaced CodeGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Akka.Interfaced;
using Akka.Actor;
using ProtoBuf;
using TypeAlias;
using System.ComponentModel;

#region Domain.IUser

namespace Domain
{
    [PayloadTable(typeof(IUser), PayloadTableKind.Request)]
    public static class IUser_PayloadTable
    {
        public static Type[,] GetPayloadTypes()
        {
            return new Type[,] {
                { typeof(AddNote_Invoke), null },
                { typeof(RemoveNote_Invoke), null },
                { typeof(SetNickname_Invoke), null },
            };
        }

        [ProtoContract, TypeAlias]
        public class AddNote_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            [ProtoMember(1)] public int id;
            [ProtoMember(2)] public string note;

            public Type GetInterfaceType()
            {
                return typeof(IUser);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                await ((IUser)__target).AddNote(id, note);
                return null;
            }
        }

        [ProtoContract, TypeAlias]
        public class RemoveNote_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            [ProtoMember(1)] public int id;

            public Type GetInterfaceType()
            {
                return typeof(IUser);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                await ((IUser)__target).RemoveNote(id);
                return null;
            }
        }

        [ProtoContract, TypeAlias]
        public class SetNickname_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            [ProtoMember(1)] public string nickname;

            public Type GetInterfaceType()
            {
                return typeof(IUser);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                await ((IUser)__target).SetNickname(nickname);
                return null;
            }
        }
    }

    public interface IUser_NoReply
    {
        void AddNote(int id, string note);
        void RemoveNote(int id);
        void SetNickname(string nickname);
    }

    public class UserRef : InterfacedActorRef, IUser, IUser_NoReply
    {
        public override Type InterfaceType => typeof(IUser);

        public UserRef() : base(null)
        {
        }

        public UserRef(IRequestTarget target) : base(target)
        {
        }

        public UserRef(IRequestTarget target, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(target, requestWaiter, timeout)
        {
        }

        public IUser_NoReply WithNoReply()
        {
            return this;
        }

        public UserRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new UserRef(Target, requestWaiter, Timeout);
        }

        public UserRef WithTimeout(TimeSpan? timeout)
        {
            return new UserRef(Target, RequestWaiter, timeout);
        }

        public Task AddNote(int id, string note)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IUser_PayloadTable.AddNote_Invoke { id = id, note = note }
            };
            return SendRequestAndWait(requestMessage);
        }

        public Task RemoveNote(int id)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IUser_PayloadTable.RemoveNote_Invoke { id = id }
            };
            return SendRequestAndWait(requestMessage);
        }

        public Task SetNickname(string nickname)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IUser_PayloadTable.SetNickname_Invoke { nickname = nickname }
            };
            return SendRequestAndWait(requestMessage);
        }

        void IUser_NoReply.AddNote(int id, string note)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IUser_PayloadTable.AddNote_Invoke { id = id, note = note }
            };
            SendRequest(requestMessage);
        }

        void IUser_NoReply.RemoveNote(int id)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IUser_PayloadTable.RemoveNote_Invoke { id = id }
            };
            SendRequest(requestMessage);
        }

        void IUser_NoReply.SetNickname(string nickname)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IUser_PayloadTable.SetNickname_Invoke { nickname = nickname }
            };
            SendRequest(requestMessage);
        }
    }

    [ProtoContract]
    public class SurrogateForIUser
    {
        [ProtoMember(1)] public IRequestTarget Target;

        [ProtoConverter]
        public static SurrogateForIUser Convert(IUser value)
        {
            if (value == null) return null;
            return new SurrogateForIUser { Target = ((UserRef)value).Target };
        }

        [ProtoConverter]
        public static IUser Convert(SurrogateForIUser value)
        {
            if (value == null) return null;
            return new UserRef(value.Target);
        }
    }

    [AlternativeInterface(typeof(IUser))]
    public interface IUserSync : IInterfacedActorSync
    {
        void AddNote(int id, string note);
        void RemoveNote(int id);
        void SetNickname(string nickname);
    }
}

#endregion
#region Domain.IUserInitiator

namespace Domain
{
    [PayloadTable(typeof(IUserInitiator), PayloadTableKind.Request)]
    public static class IUserInitiator_PayloadTable
    {
        public static Type[,] GetPayloadTypes()
        {
            return new Type[,] {
                { typeof(Create_Invoke), typeof(Create_Return) },
                { typeof(Load_Invoke), typeof(Load_Return) },
            };
        }

        [ProtoContract, TypeAlias]
        public class Create_Invoke
            : IInterfacedPayload, IAsyncInvokable, IPayloadObserverUpdatable
        {
            [ProtoMember(1)] public Domain.IUserEventObserver observer;
            [ProtoMember(2)] public string nickname;

            public Type GetInterfaceType()
            {
                return typeof(IUserInitiator);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((IUserInitiator)__target).Create(observer, nickname);
                return (IValueGetable)(new Create_Return { v = __v });
            }

            void IPayloadObserverUpdatable.Update(Action<IInterfacedObserver> updater)
            {
                if (observer != null)
                {
                    updater(observer);
                }
            }
        }

        [ProtoContract, TypeAlias]
        public class Create_Return
            : IInterfacedPayload, IValueGetable
        {
            [ProtoMember(1)] public Domain.TrackableUserContext v;

            public Type GetInterfaceType()
            {
                return typeof(IUserInitiator);
            }

            public object Value
            {
                get { return v; }
            }
        }

        [ProtoContract, TypeAlias]
        public class Load_Invoke
            : IInterfacedPayload, IAsyncInvokable, IPayloadObserverUpdatable
        {
            [ProtoMember(1)] public Domain.IUserEventObserver observer;

            public Type GetInterfaceType()
            {
                return typeof(IUserInitiator);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((IUserInitiator)__target).Load(observer);
                return (IValueGetable)(new Load_Return { v = __v });
            }

            void IPayloadObserverUpdatable.Update(Action<IInterfacedObserver> updater)
            {
                if (observer != null)
                {
                    updater(observer);
                }
            }
        }

        [ProtoContract, TypeAlias]
        public class Load_Return
            : IInterfacedPayload, IValueGetable
        {
            [ProtoMember(1)] public Domain.TrackableUserContext v;

            public Type GetInterfaceType()
            {
                return typeof(IUserInitiator);
            }

            public object Value
            {
                get { return v; }
            }
        }
    }

    public interface IUserInitiator_NoReply
    {
        void Create(Domain.IUserEventObserver observer, string nickname);
        void Load(Domain.IUserEventObserver observer);
    }

    public class UserInitiatorRef : InterfacedActorRef, IUserInitiator, IUserInitiator_NoReply
    {
        public override Type InterfaceType => typeof(IUserInitiator);

        public UserInitiatorRef() : base(null)
        {
        }

        public UserInitiatorRef(IRequestTarget target) : base(target)
        {
        }

        public UserInitiatorRef(IRequestTarget target, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(target, requestWaiter, timeout)
        {
        }

        public IUserInitiator_NoReply WithNoReply()
        {
            return this;
        }

        public UserInitiatorRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new UserInitiatorRef(Target, requestWaiter, Timeout);
        }

        public UserInitiatorRef WithTimeout(TimeSpan? timeout)
        {
            return new UserInitiatorRef(Target, RequestWaiter, timeout);
        }

        public Task<Domain.TrackableUserContext> Create(Domain.IUserEventObserver observer, string nickname)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IUserInitiator_PayloadTable.Create_Invoke { observer = (UserEventObserver)observer, nickname = nickname }
            };
            return SendRequestAndReceive<Domain.TrackableUserContext>(requestMessage);
        }

        public Task<Domain.TrackableUserContext> Load(Domain.IUserEventObserver observer)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IUserInitiator_PayloadTable.Load_Invoke { observer = (UserEventObserver)observer }
            };
            return SendRequestAndReceive<Domain.TrackableUserContext>(requestMessage);
        }

        void IUserInitiator_NoReply.Create(Domain.IUserEventObserver observer, string nickname)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IUserInitiator_PayloadTable.Create_Invoke { observer = (UserEventObserver)observer, nickname = nickname }
            };
            SendRequest(requestMessage);
        }

        void IUserInitiator_NoReply.Load(Domain.IUserEventObserver observer)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IUserInitiator_PayloadTable.Load_Invoke { observer = (UserEventObserver)observer }
            };
            SendRequest(requestMessage);
        }
    }

    [ProtoContract]
    public class SurrogateForIUserInitiator
    {
        [ProtoMember(1)] public IRequestTarget Target;

        [ProtoConverter]
        public static SurrogateForIUserInitiator Convert(IUserInitiator value)
        {
            if (value == null) return null;
            return new SurrogateForIUserInitiator { Target = ((UserInitiatorRef)value).Target };
        }

        [ProtoConverter]
        public static IUserInitiator Convert(SurrogateForIUserInitiator value)
        {
            if (value == null) return null;
            return new UserInitiatorRef(value.Target);
        }
    }

    [AlternativeInterface(typeof(IUserInitiator))]
    public interface IUserInitiatorSync : IInterfacedActorSync
    {
        Domain.TrackableUserContext Create(Domain.IUserEventObserver observer, string nickname);
        Domain.TrackableUserContext Load(Domain.IUserEventObserver observer);
    }
}

#endregion
#region Domain.IUserLogin

namespace Domain
{
    [PayloadTable(typeof(IUserLogin), PayloadTableKind.Request)]
    public static class IUserLogin_PayloadTable
    {
        public static Type[,] GetPayloadTypes()
        {
            return new Type[,] {
                { typeof(Login_Invoke), typeof(Login_Return) },
            };
        }

        [ProtoContract, TypeAlias]
        public class Login_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            [ProtoMember(1)] public string credential;

            public Type GetInterfaceType()
            {
                return typeof(IUserLogin);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((IUserLogin)__target).Login(credential);
                return (IValueGetable)(new Login_Return { v = __v });
            }
        }

        [ProtoContract, TypeAlias]
        public class Login_Return
            : IInterfacedPayload, IValueGetable, IPayloadActorRefUpdatable
        {
            [ProtoMember(1)] public System.Tuple<long, Domain.IUserInitiator> v;

            public Type GetInterfaceType()
            {
                return typeof(IUserLogin);
            }

            public object Value
            {
                get { return v; }
            }

            void IPayloadActorRefUpdatable.Update(Action<object> updater)
            {
                if (v != null)
                {
                    if (v.Item2 != null) updater(v.Item2);
                }
            }
        }
    }

    public interface IUserLogin_NoReply
    {
        void Login(string credential);
    }

    public class UserLoginRef : InterfacedActorRef, IUserLogin, IUserLogin_NoReply
    {
        public override Type InterfaceType => typeof(IUserLogin);

        public UserLoginRef() : base(null)
        {
        }

        public UserLoginRef(IRequestTarget target) : base(target)
        {
        }

        public UserLoginRef(IRequestTarget target, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(target, requestWaiter, timeout)
        {
        }

        public IUserLogin_NoReply WithNoReply()
        {
            return this;
        }

        public UserLoginRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new UserLoginRef(Target, requestWaiter, Timeout);
        }

        public UserLoginRef WithTimeout(TimeSpan? timeout)
        {
            return new UserLoginRef(Target, RequestWaiter, timeout);
        }

        public Task<System.Tuple<long, Domain.IUserInitiator>> Login(string credential)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IUserLogin_PayloadTable.Login_Invoke { credential = credential }
            };
            return SendRequestAndReceive<System.Tuple<long, Domain.IUserInitiator>>(requestMessage);
        }

        void IUserLogin_NoReply.Login(string credential)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IUserLogin_PayloadTable.Login_Invoke { credential = credential }
            };
            SendRequest(requestMessage);
        }
    }

    [ProtoContract]
    public class SurrogateForIUserLogin
    {
        [ProtoMember(1)] public IRequestTarget Target;

        [ProtoConverter]
        public static SurrogateForIUserLogin Convert(IUserLogin value)
        {
            if (value == null) return null;
            return new SurrogateForIUserLogin { Target = ((UserLoginRef)value).Target };
        }

        [ProtoConverter]
        public static IUserLogin Convert(SurrogateForIUserLogin value)
        {
            if (value == null) return null;
            return new UserLoginRef(value.Target);
        }
    }

    [AlternativeInterface(typeof(IUserLogin))]
    public interface IUserLoginSync : IInterfacedActorSync
    {
        System.Tuple<long, Domain.IUserInitiator> Login(string credential);
    }
}

#endregion
#region Domain.IUserEventObserver

namespace Domain
{
    [PayloadTable(typeof(IUserEventObserver), PayloadTableKind.Notification)]
    public static class IUserEventObserver_PayloadTable
    {
        public static Type[] GetPayloadTypes()
        {
            return new Type[] {
                typeof(UserContextChange_Invoke),
            };
        }

        [ProtoContract, TypeAlias]
        public class UserContextChange_Invoke : IInterfacedPayload, IInvokable
        {
            [ProtoMember(1)] public Domain.TrackableUserContextTracker userContextTracker;

            public Type GetInterfaceType()
            {
                return typeof(IUserEventObserver);
            }

            public void Invoke(object __target)
            {
                ((IUserEventObserver)__target).UserContextChange(userContextTracker);
            }
        }
    }

    public class UserEventObserver : InterfacedObserver, IUserEventObserver
    {
        public UserEventObserver()
            : base(null, 0)
        {
        }

        public UserEventObserver(INotificationChannel channel, int observerId = 0)
            : base(channel, observerId)
        {
        }

        public void UserContextChange(Domain.TrackableUserContextTracker userContextTracker)
        {
            var payload = new IUserEventObserver_PayloadTable.UserContextChange_Invoke { userContextTracker = userContextTracker };
            Notify(payload);
        }
    }

    [ProtoContract]
    public class SurrogateForIUserEventObserver
    {
        [ProtoMember(1)] public INotificationChannel Channel;
        [ProtoMember(2)] public int ObserverId;

        [ProtoConverter]
        public static SurrogateForIUserEventObserver Convert(IUserEventObserver value)
        {
            if (value == null) return null;
            var o = (UserEventObserver)value;
            return new SurrogateForIUserEventObserver { Channel = o.Channel, ObserverId = o.ObserverId };
        }

        [ProtoConverter]
        public static IUserEventObserver Convert(SurrogateForIUserEventObserver value)
        {
            if (value == null) return null;
            return new UserEventObserver(value.Channel, value.ObserverId);
        }
    }

    [AlternativeInterface(typeof(IUserEventObserver))]
    public interface IUserEventObserverAsync : IInterfacedObserverSync
    {
        Task UserContextChange(Domain.TrackableUserContextTracker userContextTracker);
    }
}

#endregion
