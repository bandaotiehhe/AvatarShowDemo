using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LR
{
    //被装饰类型
    class MyAvatarShow : BaseAvatarShow
    {
        //所有装饰器共同访问的数据
        AvatarShowData m_AvatarData;

        BaseDecorator m_MyDecorator;

        List<DecoratorType> m_DecoratorTypes;

        public MyAvatarShow(string name)
        {
            m_AvatarData = new AvatarShowData();
            m_AvatarData.name = name;
        }

        public override void SetPos()
        {
            Debugger.LogError(m_AvatarData.name + ": SetPos");
        }

        public override void LoadAvatar()
        {
            Debugger.LogError(m_AvatarData.name + ": LoadAvatar");
        }

        void Update()
        {
            m_MyDecorator?.Update();
        }

        public MyAvatarShow AppendDecorator(DecoratorType type)
        {
            if (m_DecoratorTypes == null)
            {
                m_DecoratorTypes = new List<DecoratorType>();
            }

            if (m_DecoratorTypes.Contains(type))
            {
                //show error
                return null;
            }

            m_DecoratorTypes.Add(type);
            return this;
        }

        public void ClearDecorator()
        {

            m_DecoratorTypes?.Clear();
            m_MyDecorator?.Disconnect();
        }

        public BaseDecorator BuildDecorator()
        {
            if (m_DecoratorTypes == null || m_DecoratorTypes.Count == 0)
            {
                //show error
                return null;
            }

            m_MyDecorator?.Disconnect();

            m_MyDecorator = DecoratorFactory.CreateDecoratorWithType(m_DecoratorTypes[0], this, m_AvatarData);

            BaseDecorator result = m_MyDecorator;

            for (int i = 1; i < m_DecoratorTypes.Count; i++)
            {
                result = result.AppendDecorator(m_DecoratorTypes[i]);
            }

            m_DecoratorTypes.Clear();
            return result;
        }

        public T FindDecorator<T>() where T : BaseDecorator
        {
            return DecoratorFactory.FindDecorator<T>(this, m_MyDecorator);
        }
    }
}
