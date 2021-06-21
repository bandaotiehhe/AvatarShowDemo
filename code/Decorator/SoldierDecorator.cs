using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoulEngine;

namespace LR
{
    //eg：Soldier  AvatarShow
    class SoldierDecorator : TypeDecorator
    {
        //Soldier Config

        public SoldierDecorator(IAvatarShow avatarShow, AvatarShowData avatarData) : base(avatarShow, avatarData) { }

        public void InitSoldier()
        {
            Debugger.LogError(m_AvatarData.name + ": InitSoldier");
        }

        protected override void OnUpdate()
        {
            Debugger.LogError(m_AvatarData.name + "  Soldier : OnUpdate");
        }
    }
}
