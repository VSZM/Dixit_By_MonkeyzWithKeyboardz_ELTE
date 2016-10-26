﻿using Dixit_ServiceLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Dixit_Logic.Interfaces;
using System.Reflection;

namespace Dixit_Service
{
    [ServiceKnownType("RegisterKnownTypes", typeof(DixitService))]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class DixitService : IDixitService
    {
        public CreateGameResult CreateGame(string name)
        {
            throw new NotImplementedException();
        }

        public JoinGameResult JoinGame(IDixitGame game)
        {
            throw new NotImplementedException();
        }

        public void LeaveGame(IDixitGame game)
        {
            throw new NotImplementedException();
        }

        public List<IDixitGame> ListGames()
        {
            throw new NotImplementedException();
        }

        public void Login()
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public SelectCardResult SelectCard(IDixitGame game, ICard card)
        {
            throw new NotImplementedException();
        }

        public SelectCardResult SelectCardWithStory(IDixitGame game, ICard card, string story)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Type> RegisterKnownTypes(ICustomAttributeProvider provider)
        {
            return Dixit_Logic.KnownTypesProvider.GetKnownTypes();
        }
    }
}
