using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoulEngine;

namespace LR
{
    //显示装饰器
    class GraphicDecorator : BaseDecorator
    {
        public enum FuncType
        {
            SetGray,
            SetOutline,
            //more
        }

        public GraphicDecorator(IAvatarShow avatarShow, AvatarShowData avatarData) : base(avatarShow, avatarData)
        {
            m_DecoratorType = DecoratorType.Graphic;
        }


        public override IVarList TryExecuteGraphicFunc(FuncType funcType, IVarList varList)
        {
            switch (funcType)
            {
                case FuncType.SetGray:
                    SetGray();
                    return null;
                case FuncType.SetOutline:
                    return SetOutline(varList);
                default:
                    return null;
            }
        }

        protected override void OnUpdate()
        {
            Debugger.LogError(m_AvatarData.name + "  Graphic : OnUpdate");
        }

        void SetGray()
        {
            Debugger.LogError(m_AvatarData.name + "  Graphic : SetGray");
        }

        IVarList SetOutline(IVarList varList)
        {
            Debugger.LogError(m_AvatarData.name + "  Graphic : SetOutline");
            return null;
        }
    }
}
