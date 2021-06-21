using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoulEngine;

namespace LR
{
    //父类虚方法实现
    class BaseAvatarShow : SoulMonoBehaviour, IAvatarShow
    {
        public virtual void SetPos() { }
        public virtual void LoadAvatar() { }

        public virtual IVarList ExecuteEffectFunc(DecoratorType decoratorType, EffectDecorator.FuncType funcType, IVarList varList = null) { return null; }
        public virtual IVarList ExecuteActionFunc(DecoratorType decoratorType, ActionDecorator.FuncType funcType, IVarList varList = null) { return null; }
        public virtual IVarList ExecuteGraphicEffectFunc(DecoratorType decoratorType, GraphicDecorator.FuncType funcType, IVarList varList = null) { return null; }

        public virtual BaseDecorator AppendDecorator(DecoratorType type) { return null; }
    }
}
