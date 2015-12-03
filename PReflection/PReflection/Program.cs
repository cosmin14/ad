using System;
using System.Reflection;

namespace PReflection
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			int i=33;
			Type typeI = i.GetType();
			showType (typeI);


			string s="Hola";
			Type typeS = s.GetType();
			showType (typeS);

			Type typeX = typeof(string);
			showType (typeX);

			Type typeFoo = typeof(Foo);
			showType (typeFoo);
		}
		private static void showType(Type type){
			Console.WriteLine ("type.Name={0} type.fullName{1}", type.Name, type.FullName);
			PropertyInfo[] propertyInfos = type.GetProperties ();

			foreach (PropertyInfo propertyInfo in propertyInfos) {
				Console.WriteLine ("propertyInfo.Name={0}", propertyInfo.Name);
			}
		}
	}
	public class Foo{
		private object id;

		public object Id {
			get {
				return id;
			}
			set {
				id = value;
			}
		}

		private string name;
		public string Name{
			get{
				return name;
			}
			set{
				name = value;
			}
		}
	}
}