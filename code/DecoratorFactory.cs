using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LR
{
    //适配器工厂
    class DecoratorFactory
    {
        public static T FindDecorator<T>(IAvatarShow self, BaseDecorator next) where T : BaseDecorator
        {

            if (self is T)
            {
                return self as T;
            }
            else
            {
                if (next == null)
                {
                    return null;
                }
                else
                {
                    return next.FindDecorator<T>();
                }
            }
        }


        public static BaseDecorator CreateDecoratorWithType(DecoratorType type, IAvatarShow avatar, AvatarShowData avatarData)
        {
            BaseDecorator decorator;
            switch (type)
            {
                case DecoratorType.Effect:
                    decorator = new EffectDecorator(avatar, avatarData);
                    break;
                case DecoratorType.Action:
                    decorator = new ActionDecorator(avatar, avatarData);
                    break;
                case DecoratorType.Graphic:
                    decorator = new GraphicDecorator(avatar, avatarData);
                    break;
                case DecoratorType.Soldier:
                    decorator = new SoldierDecorator(avatar, avatarData);
                    break;
                default:
                    decorator = null;
                    break;
            }
            return decorator;
        }
    }
}
