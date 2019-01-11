using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;


namespace IQTools
{
	class SyntaxColoringRichEditBox : RichTextBox
	{
		static string[] keywords = { "select", "from", "where", "order", "group", "by", "union", "inner", "outer", "join",
			"distinct", "all", "with", "case", "when", "then", "like", "in", "and", "or", "begin", "end", "between", "break", 
			"continue", "desc", "asc", "if", "else", "exec", "execute", "exists", "for", "goto", "having", "top", "as", 
			"left", "right", "on" };

		public SyntaxColoringRichEditBox()
		{
			Colorize();
		}

		protected override void OnTextChanged(EventArgs e)
		{
			Colorize();

			base.OnTextChanged(e);
		}

		private const int WM_SETREDRAW = 0x000B;
		private const int WM_USER = 0x400;
		private const int EM_GETEVENTMASK = (WM_USER + 59);
		private const int EM_SETEVENTMASK = (WM_USER + 69);
      
		[DllImport("user32.dll")]
		private extern static IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);

		private void Colorize()
		{
			IntPtr eventMask = IntPtr.Zero;

			try
			{
				// Stop redrawing:
				SendMessage(this.Handle, WM_SETREDRAW, 0, IntPtr.Zero);
				
				// Stop sending of events:
				eventMask = SendMessage(this.Handle, EM_GETEVENTMASK, 0, IntPtr.Zero);

				// colorize

				int oldSelectionStart = this.SelectionStart;
				int oldSelectionLength = this.SelectionLength;
                int x = 0;

                Regex r = new Regex("([\\n \\t{}().,:;])");
				string[] words = r.Split(this.Text);
                
        

				foreach (string word in words)
				{
					this.SelectionStart = x;
					this.SelectionLength = word.Length;
					this.SelectionColor = Color.Black;

					foreach (string keyword in keywords)
					{
						if (String.Compare(word, keyword, true) == 0)
						{
							this.SelectionColor = Color.Navy;
							break;
						}
					}
					x += word.Length;
				}

				this.SelectionStart = oldSelectionStart;
				this.SelectionLength = oldSelectionLength;
			}
			finally
			{
				// turn on events
				SendMessage(this.Handle, EM_SETEVENTMASK, 0, eventMask);

				// turn on redrawing
				SendMessage(this.Handle, WM_SETREDRAW, 1, IntPtr.Zero);

				this.Invalidate();
			}
		}
	}
}
