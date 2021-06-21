using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoulEngine;

namespace LR
{
    //定义通用行为接口 
    interface IAvatarShow
    {
        //Transform相关
        void SetPos();
        //加载相关
        void LoadAvatar();

        //特效相关
        IVarList ExecuteEffectFunc(DecoratorType decoratorType, EffectDecorator.FuncType funcType, IVarList varList);
        //动作相关
        IVarList ExecuteActionFunc(DecoratorType decoratorType, ActionDecorator.FuncType funcType, IVarList varList);
        //显示相关
        IVarList ExecuteGraphicEffectFunc(DecoratorType decoratorType, GraphicDecorator.FuncType funcType, IVarList varList);
    }
}
 