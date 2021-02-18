using Microsoft.Web.WebView2;
using Microsoft.Web.WebView2.Core;
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml;

namespace ThreeHost
{
	public partial class BrowserForm : Form
	{
		protected AutoResetEvent evReady;
		string curAppUrl, curAppDir;
		string curContentJson, curContentDir;

		//Dictionary<string, List<string>> contentItems = new Dictionary<string, List<string>>();

		public BrowserForm()
		{
			evReady = new AutoResetEvent(false);

			InitializeComponent();
			HandleResize();

			Program.app_server.StartServer();
			Program.content_server.StartServer();
		}

		public void DumpSettings()
		{
			System.Collections.IEnumerator en;

			Properties.Settings.Default.ContentReferences.Clear();
			en = contentTree.Nodes.GetEnumerator();
			while (en.MoveNext())
			{
				ContentTreeNode ctn = (ContentTreeNode)en.Current;
				if (ctn.Parent == null)
				{
					Properties.Settings.Default.ContentReferences.Add(ctn.rootPath);
				}
			}

			Properties.Settings.Default.AppReferences.Clear();
			en = appList.Items.GetEnumerator();
			while (en.MoveNext())
			{
				string s = (string)en.Current;
				Properties.Settings.Default.AppReferences.Add(s);
			}

			Properties.Settings.Default.Save();
		}

		#region Event Handlers
		private void WebView2Control_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
		{
		}

		private void WebView2Control_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
		{
		}

		private void WebView2Control_SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
		{
			//txtUrl.Text = webView2Control.Source.AbsoluteUri;
		}

		private void WebView2Control_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
		{
			if (!e.IsSuccess)
			{
				MessageBox.Show($"WebView2 creation failed with exception = {e.InitializationException}");
				return;
			}

			evReady.Set();

			webView2Control.CoreWebView2.FrameNavigationCompleted += WebView2Control_NavComplete;
			//webView2Control.CoreWebView2.SourceChanged += CoreWebView2_SourceChanged;
			//webView2Control.CoreWebView2.HistoryChanged += CoreWebView2_HistoryChanged;
			//webView2Control.CoreWebView2.DocumentTitleChanged += CoreWebView2_DocumentTitleChanged;
			//webView2Control.CoreWebView2.AddWebResourceRequestedFilter("*", CoreWebView2WebResourceContext.Image);
		}

		private void WebView2Control_NavComplete(object sender, CoreWebView2NavigationCompletedEventArgs e)
		{
			//Program.server.UpdateRootDir(curContentDir);

			Thread.Sleep(1);

			webView2Control.CoreWebView2.PostWebMessageAsJson(curContentJson);
		}

		private void WebView2Control_KeyUp(object sender, KeyEventArgs e)
		{
		}

		private void WebView2Control_KeyDown(object sender, KeyEventArgs e)
		{
		}

		private void WebView2Control_AcceleratorKeyPressed(object sender, Microsoft.Web.WebView2.Core.CoreWebView2AcceleratorKeyPressedEventArgs e)
		{
		}

		private void CoreWebView2_SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
		{
		}

		private void CoreWebView2_DocumentTitleChanged(object sender, object e)
		{
			this.Text = this.webView2Control.CoreWebView2.DocumentTitle;
		}
		#endregion

		#region UI event handlers
		private void BtnRefresh_Click(object sender, EventArgs e)
		{
			webView2Control.Reload();
		}

		/*

		private void CoreWebView2_HistoryChanged(object sender, object e)
		{
		}

		private void BtnGo_Click(object sender, EventArgs e)
		{
			webView2Control.Source = new Uri(txtUrl.Text);
		}

		private void BtnBack_Click(object sender, EventArgs e)
		{
			webView2Control.GoBack();
		}

		private void BtnForward_Click(object sender, EventArgs e)
		{
			webView2Control.GoForward();
		}

		*/

		private void Form_Resize(object sender, EventArgs e)
		{
			HandleResize();
		}
		#endregion

		private void HandleResize()
		{
			// Resize the webview
			webView2Control.Size = this.ClientSize - new System.Drawing.Size(webView2Control.Location);
		}

		private void SetStatusText(string s)
		{
			if (InvokeRequired)
			{
				try
				{
					this.Invoke(new Action<string>(SetStatusText), new object[] { s });
				}
				catch (Exception)
				{
				}

				return;
			}

			statusLabel.Text = s;
		}

		private int typeTabDisableCount = 0;

		private void EnableTypeTabs(bool b)
		{
			if (InvokeRequired)
			{
				try
				{
					this.Invoke(new Action<bool>(EnableTypeTabs), new object[] { b });
				}
				catch (Exception)
				{
				}

				return;
			}

			try
			{
				if (typeTabDisableCount == 0)
					typeTabs.Enabled = b;

				if (!b)
					typeTabDisableCount++;
				else if (typeTabDisableCount > 0)
					typeTabDisableCount--;

				if (typeTabDisableCount > 0)
					SetStatusText("Reading content...");
				else
					SetStatusText("Ready");
			}
			catch (Exception)
			{
			}
		}

		private delegate void metaDataProcessorDelegate(ContentTreeNode node);

		//Dictionary<string, IList<string>> 
		private void AddTreeItemAsync(TreeView tv, string parentname, string name, string path, metaDataProcessorDelegate mdp = null)
		{
			if (InvokeRequired)
			{
				try
				{
					this.Invoke(new Action<TreeView, string, string, string, metaDataProcessorDelegate>(AddTreeItemAsync), new object[] { tv, parentname, name, path, mdp });
				}
				catch (Exception)
				{
				}

				return;
			}

			ContentTreeNode parentnode = null;
			if ((parentname != null) && (parentname.Length > 0))
			{
				foreach (ContentTreeNode node in tv.Nodes)
				{
					if (node.Text == parentname)
					{
						parentnode = node;
						break;
					}
				}
			}

			ContentTreeNode ctn = new ContentTreeNode(name, path);
			ctn.Text = name;// (parentnode == null) ? name : Path.GetFileName(name);
			if (parentnode != null)
				ctn.rootPath = Path.GetDirectoryName(name);

			if (parentnode == null)
				tv.Nodes.Add(ctn);
			else
				parentnode.Nodes.Add(ctn);

			if (mdp != null)
				mdp(ctn);
		}

		private uint AddFilesInFolder(string path, string spec, metaDataProcessorDelegate mdp = null)
		{
			int n = path.Length;
			uint ret = 0;

			System.Collections.Generic.IEnumerable<string> allfiles;
			try
			{
				allfiles = Directory.EnumerateFiles(path, spec, SearchOption.AllDirectories);
			}
			catch (DirectoryNotFoundException)
			{
				// an exception is thrown for empty directories... so just return false if that happens
				return 0;
			}
			catch (Exception)
			{
				return 0;
			}

			foreach (string f in allfiles)
			{
				string s = f.Remove(0, n);
				char[] trimchars = { '\\', '/' };
				s = s.TrimStart(trimchars).Replace('\\', '/');

				string fp = f.ToLower().Replace('\\', '/');

				AddTreeItemAsync(contentTree, path, s, fp, mdp);

				ret++;
			}

			return ret;
		}

		public bool AddContentFolder(string path, string name)
		{
			//EnableTypeTabs(false);

			if (AddFilesInFolder(path, "*.fbx", delegate (ContentTreeNode node)
			{
				XmlTextReader reader = null;
				string filename = Path.ChangeExtension(node.fullpath, "xml");
				if (!File.Exists(filename))
					return;

				try
				{
					reader = new XmlTextReader(filename);

					while (reader.Read())
					{
						switch (reader.NodeType)
						{
							case XmlNodeType.Element:
								Console.Write("<{0}>", reader.Name);
								break;
							case XmlNodeType.Text:
								Console.Write(reader.Value);
								break;
							case XmlNodeType.CDATA:
								Console.Write("<![CDATA[{0}]]>", reader.Value);
								break;
							case XmlNodeType.ProcessingInstruction:
								Console.Write("<?{0} {1}?>", reader.Name, reader.Value);
								break;
							case XmlNodeType.Comment:
								Console.Write("<!--{0}-->", reader.Value);
								break;
							case XmlNodeType.XmlDeclaration:
								Console.Write("<?xml version='1.0'?>");
								break;
							case XmlNodeType.Document:
								break;
							case XmlNodeType.DocumentType:
								Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
								break;
							case XmlNodeType.EntityReference:
								Console.Write(reader.Name);
								break;
							case XmlNodeType.EndElement:
								Console.Write("</{0}>", reader.Name);
								break;
						}
					}
				}

				finally
				{
					if (reader != null)
						reader.Close();
				}

			}) <= 0)
			{
			}

			//EnableTypeTabs(true);

			return true;
		}

		private void AddContentFolderButton_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();

			if (fbd.ShowDialog() == DialogResult.OK)
			{
				string p = fbd.SelectedPath.ToLower().Replace('\\', '/'); ;

				foreach (ContentTreeNode node in contentTree.Nodes)
				{
					if (node.Text == p)
					{
						MessageBox.Show(string.Format("\"{0}\" is already referenced.", fbd.SelectedPath));
						return;
					}
				}

				AddTreeItemAsync(contentTree, null, p, fbd.SelectedPath, null);

				Task t = new Task(() => { AddContentFolder(p, p); });
				t.Start();
			}
		}

		private void RemoveContentFolderButton_Click(object sender, EventArgs e)
		{
			if ((contentTree.SelectedNode != null) && (contentTree.SelectedNode.Parent == null))
			{
				if (MessageBox.Show(String.Format("Really remove the content reference to \"{0}\"?", contentTree.SelectedNode.Text), "Confirm Content Reference Removal", MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					contentTree.SelectedNode.Remove();
				}
			}
		}

		protected class JSMessage
		{
			public JSMessage(string msg) { message = msg; }
			public string message { get; set; }
		}

		protected sealed class LoadModelMessage : JSMessage
		{
			public LoadModelMessage(string modelpath) : base("loadmodel") { path = modelpath; }
			public string path { get; set; }
		}

		private void ContentTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			ContentTreeNode ctn = (ContentTreeNode)e.Node;
			bool isfolder = (ctn.Parent == null) ? true : false;
			removeContentFolderButton.Enabled = isfolder;

			webView2Control.CoreWebView2.Stop();

			if (!isfolder)
			{
				curContentDir = ctn.Parent.Text;
				Program.content_server.UpdateRootDir(curContentDir);

				Thread.Sleep(1);

				string url = Program.content_server.BaseRequestUrl() + ctn.Text;

				curContentJson = JsonConvert.SerializeObject(new LoadModelMessage(url));
				webView2Control.CoreWebView2.PostWebMessageAsJson(curContentJson);
			}
		}

		public bool AddApplication(string filename)
		{
			if (appList.Items.Contains(filename))
				return false;

			int ii = appList.Items.Add(filename);
			if (ii < 0)
				return false;

			appList.SetItemChecked(ii, true);

			return true;
		}

		private void addAppButton_Click(object sender, EventArgs e)
		{
			FileDialog fd = new OpenFileDialog();
			fd.Filter = "html files (*.html)|*.html|All files (*.*)|*.*";
			fd.RestoreDirectory = true;
			fd.CheckFileExists = true;

			if (fd.ShowDialog() == DialogResult.OK)
			{
				if (!AddApplication(fd.FileName))
				{
					MessageBox.Show(string.Format("\"{0}\" is already referenced.", fd.FileName));
					return;
				}
			}
		}

		private void removeAppButton_Click(object sender, EventArgs e)
		{
			if (appList.SelectedIndex >= 0)
			{
				if (MessageBox.Show("Really remove the reference to this application?", "Confirm Application Reference Removal", MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					appList.Items.RemoveAt(appList.SelectedIndex);
				}
			}
		}

		private void appList_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (e.NewValue != CheckState.Checked)
				return;

			string apppath = appList.Items[e.Index].ToString();

			string servedir = Path.GetDirectoryName(apppath);
			char[] trimchars = { '\\', '/' };
			curAppDir = servedir.TrimEnd(trimchars);
			Program.app_server.UpdateRootDir(curAppDir);

			Thread.Sleep(1);

			curAppUrl = Program.app_server.BaseRequestUrl() + Path.GetFileName(apppath);
			webView2Control.Source = new Uri(curAppUrl);
		}

		private void debugConsoleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			webView2Control.CoreWebView2.OpenDevToolsWindow();
		}

		private void InitialPanelUpdate()
		{
			System.Collections.Specialized.StringEnumerator sit;

			appList.BeginUpdate();
			sit = Properties.Settings.Default.AppReferences.GetEnumerator();
			while (sit.MoveNext())
			{
				AddApplication(sit.Current);
			}
			appList.EndUpdate();

			List<String> paths = new List<String>();
			sit = Properties.Settings.Default.ContentReferences.GetEnumerator();
			while (sit.MoveNext())
			{
				paths.Add(sit.Current);
			}

			foreach (String pu in paths)
			{
				string p = pu.ToLower();
				AddTreeItemAsync(contentTree, null, p, pu, null);

				Task t = new Task(() => { AddContentFolder(p, p); });
				t.Start();
			}
		}

		private void BrowserForm_Shown(object sender, EventArgs e)
		{
			InitialPanelUpdate();
		}

		private void webView2Control_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
		{

		}

		private void refreshAppCodeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Program.app_server.UpdateRootDir(curAppDir);

			Thread.Sleep(1);

			webView2Control.Source = new Uri(curAppUrl);
			webView2Control.Reload();

			// we don't want to have to select something else then select the content item again...
			contentTree.SelectedNode = null;
		}
	}

	internal class ContentTreeNode : TreeNode
	{
		public string rootPath, fullpath;

		public ContentTreeNode(string p, string fp)
		{
			rootPath = p;
			fullpath = fp;
		}
	}

}
