using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoulEngine;


namespace LR
{
    //装饰器父类
    class BaseDecorator : IAvatarShow
    {
        //持有更内一层装饰对象
        protected IAvatarShow m_LastDecorator;

        //持有必要数据源
        protected AvatarShowData m_AvatarData { get; private set; }

        //持有更外一层的装饰器，分发生命周期
        BaseDecorator m_NextDecorator;

        protected DecoratorType m_DecoratorType;


        public BaseDecorator(IAvatarShow avatarShow, AvatarShowData avatarData)
        {
            m_LastDecorator = avatarShow;
            m_AvatarData = avatarData;
        }

        //指回被装饰对象的实现
        public virtual void SetPos()
        {
            m_LastDecorator.SetPos();
        }

        public virtual void LoadAvatar()
        {
            m_LastDecorator.LoadAvatar();
        }


        public void Update()
        {
            m_NextDecorator?.Update();
            OnUpdate();
        }

        protected virtual void OnUpdate()
        {

        }

        public void Disconnect()
        {
            m_NextDecorator?.Disconnect();
            OnDisconnect();
        }

        protected virtual void OnDisconnect()
        {

        }


        public virtual IVarList TryExecuteEffectFunc(EffectDecorator.FuncType funcType, IVarList varList)
        {
            return null;
        }

        public virtual IVarList TryExecuteActionFunc(ActionDecorator.FuncType funcType, IVarList varList)
        {
            return null;
        }

        public virtual IVarList TryExecuteGraphicFunc(GraphicDecorator.FuncType funcType, IVarList varList)
        {
            return null;
        }

        public IVarList ExecuteEffectFunc(DecoratorType decoratorType, EffectDecorator.FuncType funcType, IVarList varList = null)
        {
            if (decoratorType == m_DecoratorType)
            {
                return TryExecuteEffectFunc(funcType, varList);
            }
            else
            {
                return m_LastDecorator.ExecuteEffectFunc(decoratorType, funcType, varList);
            }
        }

        public IVarList ExecuteActionFunc(DecoratorType decoratorType, ActionDecorator.FuncType funcType, IVarList varList = null)
        {
            if (decoratorType == m_DecoratorType)
            {
                return TryExecuteActionFunc(funcType, varList);
            }
            else
            {
                return m_LastDecorator.ExecuteActionFunc(decoratorType, funcType, varList);
            }
        }

        public IVarList ExecuteGraphicEffectFunc(DecoratorType decoratorType, GraphicDecorator.FuncType funcType, IVarList varList = null)
        {
            if (decoratorType == m_DecoratorType)
            {
                return TryExecuteGraphicFunc(funcType, varList);
            }
            else
            {
                return m_LastDecorator.ExecuteGraphicEffectFunc(decoratorType, funcType, varList);
            }
        }

        //拼接装饰器
        public BaseDecorator AppendDecorator(DecoratorType type)
        {
            m_NextDecorator = DecoratorFactory.CreateDecoratorWithType(type, this, m_AvatarData);
            return m_NextDecorator;
        }

        public T FindDecorator<T>() where T : BaseDecorator
        {
            return DecoratorFactory.FindDecorator<T>(this, m_NextDecorator);
        }
    }
}