
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell;

namespace RubikToolsAddin
{
	/// <summary>
    /// This class implements the tool window ToolWindow1ToolWindow exposed by this package and hosts a user control.
    ///
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane, 
    /// usually implemented by the package implementer.
    ///
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its 
    /// implementation of the IVsUIElementPane interface.
    /// </summary>
    [Guid("06f3c052-bd56-4953-8405-6177b0755b52")]
    public class ToolWindow1ToolWindow : ToolWindow1ToolWindowBase
    {
		ToolWindow1Control control = new ToolWindow1Control();

        /// <summary>
        /// Standard constructor for the tool window.
        /// </summary>
        public ToolWindow1ToolWindow()
        {
        }

		public override System.Windows.Forms.IWin32Window Window
        {
            get
            {
                return control;
            }
        }
	}
}