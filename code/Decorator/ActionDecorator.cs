using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoulEngine;

namespace LR
{
    //动作装饰器
    class ActionDecorator : BaseDecorator
    {
        public enum FuncType
        {
            Play,
            Stop,
            Clear
            //more
        }

        public ActionDecorator(IAvatarShow avatarShow, AvatarShowData avatarData) : base(avatarShow, avatarData)
        {
            m_DecoratorType = DecoratorType.Action;
        }

        public override IVarList TryExecuteActionFunc(FuncType funcType, IVarList varList)
        {
            switch (funcType)
            {
                case FuncType.Play:
                    Play(varList);
                    return null;
                case FuncType.Stop:
                    Stop(varList);
                    return null;
                case FuncType.Clear:
                    Clear();
                    return null;
                default:
                    return null;
            }
        }

        protected override void OnUpdate()
        {
            Debugger.LogError(m_AvatarData.name + "  Action : OnUpdate");
        }

        void Play(IVarList varList)
        {
            Debugger.LogError(m_AvatarData.name + "  Action : Play");
        }

        void Stop(IVarList varList)
        {
            Debugger.LogError(m_AvatarData.name + "  Action : Stop");
        }

        void Clear()
        {
            Debugger.LogError(m_AvatarData.name + "  Action : Clear");
        }

    }
}
