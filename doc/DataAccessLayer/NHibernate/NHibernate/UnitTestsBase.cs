using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MyGojo.Data.NHibernate;
using MyGojo.Data.NHibernate;

namespace MyGojo.Data.NHibernate
{
    public class UnitTestbase
    {
        protected IManagerFactory managerFactory = new ManagerFactory();
    }
}