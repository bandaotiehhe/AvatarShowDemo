using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoulEngine;

namespace LR
{
    //特效装饰器
    class EffectDecorator : BaseDecorator
    {
        public enum FuncType
        {
            Play,
            Stop,
            Clear
            //more
        }

        //装饰器特有数据
        int effectID;

        public EffectDecorator(IAvatarShow avatarShow, AvatarShowData avatarData) : base(avatarShow, avatarData)
        {
            m_DecoratorType = DecoratorType.Effect;
        }

        public override IVarList TryExecuteEffectFunc(FuncType funcType, IVarList varList)
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
            Debugger.LogError(m_AvatarData.name + "  Effect : OnUpdate");
        }

        void Play(IVarList varList)
        {
            Debugger.LogError(m_AvatarData.name + "  Effect : Play");
        }

        void Stop(IVarList varList)
        {
            Debugger.LogError(m_AvatarData.name + "  Effect : Stop");
        }

        void Clear()
        {
            Debugger.LogError(m_AvatarData.name + "  Effect : Clear");
        }

        protected override void OnDisconnect()
        {
            //清理手动管理的特效资源
        }
    }
}
