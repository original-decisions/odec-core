using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace odec.Framework.Infrastructure.Tests
{
    /// <summary>
    /// Class for EF Repository Testing
    /// </summary>
    /// <typeparam name="TRepository">Repository type</typeparam>
    /// <typeparam name="TContext">Context type</typeparam>
    public class RepositoryTester<TRepository,TContext>:Tester<TContext> 
        where TContext : DbContext
        where TRepository: class 
    {
        /// <summary>
        /// Repository for testing
        /// </summary>
        public TRepository Repository { get; set; }

        /// <summary>
        /// Initialazor for NUnit.framework 
        /// </summary>
        public override void Init()
        {
            base.Init();
            Repository = Activator.CreateInstance<TRepository>();//TODO:After spring refactoring
                                                                    //typeof(TRepository).GetTypeInfo().IsInterface
                                                                 // ? IocHelper.GetObject<TRepository>()
                                                                 // : Activator.CreateInstance<TRepository>();
        }
    }
}
