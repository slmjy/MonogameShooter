#region Using Statements
using System;
#if MONOMAC
using MonoMac.AppKit;
using MonoMac.Foundation;
#elif IPHONE
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Microsoft.Xna;
using Microsoft.Xna.Framework.Media;
#elif MONOMAC

#endif
#endregion

namespace MonogameShooter
{
	#region Entry Point
#if MONOMAC
	class Program
	{
		static void Main (string[] args)
		{
			NSApplication.Init ();

			using (var p = new NSAutoreleasePool ()) {
				NSApplication.SharedApplication.Delegate = new AppDelegate ();			

				NSApplication.Main (args);
			}
		}
	}

	class AppDelegate : NSApplicationDelegate
	{
		private ShooterGame game;

		public override void FinishedLaunching (MonoMac.Foundation.NSObject notification)
		{
			game = new ShooterGame ();
			game.Run();
		}

		public override bool ApplicationShouldTerminateAfterLastWindowClosed (NSApplication sender)
		{
			return true;
		}
	}
#elif IPHONE
	[Register("AppDelegate")]
	class Program : UIApplicationDelegate
	{
		ShooterGame game;
		public override void FinishedLaunching(UIApplication app)
		{
			// Fun begins..
			game = new ShooterGame();
			game.Run();
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main(string[] args)
		{
			UIApplication.Main(args, null, "AppDelegate");
		}
	}    
#elif MONOMAC
	static class Program
	{	
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main (string[] args)
		{
			MonoMac.AppKit.NSApplication.Init ();
			
			using (var p = new MonoMac.Foundation.NSAutoreleasePool ()) {
				MonoMac.AppKit.NSApplication.SharedApplication.Delegate = new AppDelegate();
				MonoMac.AppKit.NSApplication.Main(args);
			}
		}
	}
	
	class AppDelegate : MonoMac.AppKit.NSApplicationDelegate
	{
		public override void FinishedLaunching (MonoMac.Foundation.NSObject notification)
		{
			var game = new ShooterGame();
			game.Run();
		}
		
		public override bool ApplicationShouldTerminateAfterLastWindowClosed (MonoMac.AppKit.NSApplication sender)
		{
			return true;
		}
	}
#else
	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	static class Program
	{
		static void Main()
		{
			using (var game = new ShooterGame())
			{
				game.Run();
			}
		}
	}    
#endif
	#endregion
}
