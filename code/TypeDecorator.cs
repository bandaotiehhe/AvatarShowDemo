using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoulEngine;

namespace LR
{
    //如果某类AvatarShow有不能接受的特殊行为，可以扩展出一个Type装饰器, 或者认为是扩展出了一个适配器

    //类型装饰器父类，规范外界扩展时，不能更改通用行为
    class TypeDecorator : BaseDecorator
    {
        public TypeDecorator(IAvatarShow avatarShow, AvatarShowData avatarData) : base(avatarShow, avatarData)
        {
            m_DecoratorType = DecoratorType.Soldier;
        }

        public sealed override void SetPos()
        {
            base.SetPos();
        }

        public sealed override void LoadAvatar()
        {
            base.LoadAvatar();
        }

        public sealed override IVarList TryExecuteActionFunc(ActionDecorator.FuncType funcType, IVarList varList)
        {
            return base.TryExecuteActionFunc(funcType, varList);
        }

        public override IVarList TryExecuteEffectFunc(EffectDecorator.FuncType funcType, IVarList varList)
        {
            return base.TryExecuteEffectFunc(funcType, varList);
        }

        public override IVarList TryExecuteGraphicFunc(GraphicDecorator.FuncType funcType, IVarList varList)
        {
            return base.TryExecuteGraphicFunc(funcType, varList);
        }

    }
}
