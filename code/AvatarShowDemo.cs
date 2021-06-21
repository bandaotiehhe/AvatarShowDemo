using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LR;
using SoulEngine;

//装饰器 + 责任链 + 适配器

//装饰类型
public enum DecoratorType
{
    Effect,
    Action,
    Graphic,
    Soldier,
    //more
}

public class AvatarShowDemo : MonoBehaviour
{
    MyAvatarShow avatarShow_Effect;
    MyAvatarShow avatarShow_EffectAndAction;
    MyAvatarShow avatarShow_Soldier;
    void Start()
    {

        //eg.1  装饰器
        avatarShow_Effect = new MyAvatarShow("avatarShow_Effect");
        avatarShow_Effect.SetPos();
        avatarShow_Effect.LoadAvatar();

        BaseDecorator effectDecorator = avatarShow_Effect
                                        .AppendDecorator(DecoratorType.Effect)
                                        .BuildDecorator();
        effectDecorator.ExecuteEffectFunc(DecoratorType.Effect, EffectDecorator.FuncType.Play, VarList.AllocAutoVarList() < 1);
        //log
        //avatarShow_Effect: SetPos
        //avatarShow_Effect: LoadAvatar
        //avatarShow_Effect: PlayEffect



        //eg.2  责任链模式思想，链式装饰器，当最外部装饰器不具体实现时，向内层装饰器传递
        avatarShow_EffectAndAction = new MyAvatarShow("avatarShow_EffectAndAction");
        avatarShow_EffectAndAction.LoadAvatar();

        BaseDecorator effectAndActionDecorator = avatarShow_EffectAndAction
                                                 .AppendDecorator(DecoratorType.Effect)
                                                 .AppendDecorator(DecoratorType.Action)
                                                 .BuildDecorator();

        effectAndActionDecorator.ExecuteEffectFunc(DecoratorType.Effect, EffectDecorator.FuncType.Stop, VarList.AllocAutoVarList() < 1);
        effectAndActionDecorator.ExecuteActionFunc(DecoratorType.Action, ActionDecorator.FuncType.Play);

        //装饰类可直接调用被装饰类的基础实现  
        effectAndActionDecorator.SetPos();

        //未扩展对应装饰器，不生效
        effectAndActionDecorator.ExecuteGraphicEffectFunc(DecoratorType.Graphic, GraphicDecorator.FuncType.SetGray);
        //log
        //avatarShow_EffectAndAction: LoadAvatar
        //avatarShow_EffectAndAction  Effect : Stop
        //avatarShow_EffectAndAction  Action : Play
        //avatarShow_EffectAndAction: SetPos



        //eg.3   特殊类型的装饰器（可称为适配器）
        avatarShow_Soldier = new MyAvatarShow("avatarShow_Soldier");

        //链式装饰器  不可转型  某一具体类型装饰器， 只可使用通用接口
        BaseDecorator effectAndSoldierDecorator = avatarShow_Soldier
                                                  .AppendDecorator(DecoratorType.Soldier)
                                                  .AppendDecorator(DecoratorType.Effect)
                                                  .BuildDecorator();

        //BaseDecorator调用通用行为接口
        effectAndSoldierDecorator.ExecuteEffectFunc(DecoratorType.Effect, EffectDecorator.FuncType.Stop, VarList.AllocAutoVarList() < 1);

        //嵌套装饰器  通过Find使用  其中某个装饰器  的特殊行为
        avatarShow_Soldier.FindDecorator<SoldierDecorator>()?.InitSoldier();

        //log
        //avatarShow_Soldier  Effect : Stop
        //avatarShow_Soldier: InitSoldier
    }

    private void Update()
    {
        //eg.1  log
        //AvatarShow_Effect  Effect : OnUpdate

        //eg.2  log
        //avatarShow_EffectAndAction Action : OnUpdate
        //avatarShow_EffectAndAction Effect : OnUpdate

        //eg.3  log
        //avatarShow_Soldier  Soldier : OnUpdate
    }
}
