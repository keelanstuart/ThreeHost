using System;

namespace ThreeHost
{
    partial class BrowserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

			try
			{
				base.Dispose(disposing);
			}
			catch (Exception)
			{

			}
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.ToolStrip contentTabTools;
			System.Windows.Forms.ToolStripButton addContentFolderButton;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserForm));
			System.Windows.Forms.TabPage tabPageApps;
			System.Windows.Forms.ToolStrip appTabTools;
			System.Windows.Forms.ToolStripButton addAppButton;
			System.Windows.Forms.TabPage tabPageContent;
			this.removeContentFolderButton = new System.Windows.Forms.ToolStripButton();
			this.appList = new System.Windows.Forms.CheckedListBox();
			this.removeAppButton = new System.Windows.Forms.ToolStripButton();
			this.contentTree = new System.Windows.Forms.TreeView();
			this.contentImageList = new System.Windows.Forms.ImageList(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshAppCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.debugConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.xToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.xToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.xToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.statusBar = new System.Windows.Forms.StatusStrip();
			this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.typeTabs = new System.Windows.Forms.TabControl();
			this.split = new System.Windows.Forms.Splitter();
			this.webView2Control = new Microsoft.Web.WebView2.WinForms.WebView2();
			contentTabTools = new System.Windows.Forms.ToolStrip();
			addContentFolderButton = new System.Windows.Forms.ToolStripButton();
			tabPageApps = new System.Windows.Forms.TabPage();
			appTabTools = new System.Windows.Forms.ToolStrip();
			addAppButton = new System.Windows.Forms.ToolStripButton();
			tabPageContent = new System.Windows.Forms.TabPage();
			contentTabTools.SuspendLayout();
			tabPageApps.SuspendLayout();
			appTabTools.SuspendLayout();
			tabPageContent.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.statusBar.SuspendLayout();
			this.typeTabs.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.webView2Control)).BeginInit();
			this.SuspendLayout();
			// 
			// contentTabTools
			// 
			contentTabTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            addContentFolderButton,
            this.removeContentFolderButton});
			contentTabTools.Location = new System.Drawing.Point(3, 3);
			contentTabTools.Name = "contentTabTools";
			contentTabTools.Size = new System.Drawing.Size(186, 25);
			contentTabTools.TabIndex = 0;
			contentTabTools.Text = "Content Tools";
			// 
			// addContentFolderButton
			// 
			addContentFolderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			addContentFolderButton.Image = ((System.Drawing.Image)(resources.GetObject("addContentFolderButton.Image")));
			addContentFolderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			addContentFolderButton.Name = "addContentFolderButton";
			addContentFolderButton.Size = new System.Drawing.Size(23, 22);
			addContentFolderButton.Text = "Add Top-Level Content Folder";
			addContentFolderButton.Click += new System.EventHandler(this.AddContentFolderButton_Click);
			// 
			// removeContentFolderButton
			// 
			this.removeContentFolderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.removeContentFolderButton.Image = ((System.Drawing.Image)(resources.GetObject("removeContentFolderButton.Image")));
			this.removeContentFolderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.removeContentFolderButton.Name = "removeContentFolderButton";
			this.removeContentFolderButton.Size = new System.Drawing.Size(23, 22);
			this.removeContentFolderButton.Text = "Remove Top-Level Content Folder";
			this.removeContentFolderButton.Click += new System.EventHandler(this.RemoveContentFolderButton_Click);
			// 
			// tabPageApps
			// 
			tabPageApps.Controls.Add(this.appList);
			tabPageApps.Controls.Add(appTabTools);
			tabPageApps.Location = new System.Drawing.Point(4, 22);
			tabPageApps.Name = "tabPageApps";
			tabPageApps.Padding = new System.Windows.Forms.Padding(3);
			tabPageApps.Size = new System.Drawing.Size(192, 378);
			tabPageApps.TabIndex = 1;
			tabPageApps.Text = "Application";
			tabPageApps.UseVisualStyleBackColor = true;
			// 
			// appList
			// 
			this.appList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.appList.FormattingEnabled = true;
			this.appList.Location = new System.Drawing.Point(3, 28);
			this.appList.Name = "appList";
			this.appList.Size = new System.Drawing.Size(186, 347);
			this.appList.TabIndex = 1;
			this.appList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.appList_ItemCheck);
			// 
			// appTabTools
			// 
			appTabTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            addAppButton,
            this.removeAppButton});
			appTabTools.Location = new System.Drawing.Point(3, 3);
			appTabTools.Name = "appTabTools";
			appTabTools.Size = new System.Drawing.Size(186, 25);
			appTabTools.TabIndex = 0;
			appTabTools.Text = "Application Tools";
			// 
			// addAppButton
			// 
			addAppButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			addAppButton.Image = ((System.Drawing.Image)(resources.GetObject("addAppButton.Image")));
			addAppButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			addAppButton.Name = "addAppButton";
			addAppButton.Size = new System.Drawing.Size(23, 22);
			addAppButton.Text = "Add Application";
			addAppButton.Click += new System.EventHandler(this.addAppButton_Click);
			// 
			// removeAppButton
			// 
			this.removeAppButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.removeAppButton.Image = ((System.Drawing.Image)(resources.GetObject("removeAppButton.Image")));
			this.removeAppButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.removeAppButton.Name = "removeAppButton";
			this.removeAppButton.Size = new System.Drawing.Size(23, 22);
			this.removeAppButton.Text = "Remove Application";
			this.removeAppButton.Click += new System.EventHandler(this.removeAppButton_Click);
			// 
			// tabPageContent
			// 
			tabPageContent.Controls.Add(this.contentTree);
			tabPageContent.Controls.Add(contentTabTools);
			tabPageContent.Location = new System.Drawing.Point(4, 22);
			tabPageContent.Name = "tabPageContent";
			tabPageContent.Padding = new System.Windows.Forms.Padding(3);
			tabPageContent.Size = new System.Drawing.Size(192, 378);
			tabPageContent.TabIndex = 0;
			tabPageContent.Text = "Content";
			tabPageContent.UseVisualStyleBackColor = true;
			// 
			// contentTree
			// 
			this.contentTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.contentTree.FullRowSelect = true;
			this.contentTree.HideSelection = false;
			this.contentTree.Indent = 10;
			this.contentTree.Location = new System.Drawing.Point(3, 28);
			this.contentTree.Name = "contentTree";
			this.contentTree.ShowNodeToolTips = true;
			this.contentTree.Size = new System.Drawing.Size(186, 347);
			this.contentTree.StateImageList = this.contentImageList;
			this.contentTree.TabIndex = 1;
			this.contentTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ContentTree_AfterSelect);
			// 
			// contentImageList
			// 
			this.contentImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("contentImageList.ImageStream")));
			this.contentImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.contentImageList.Images.SetKeyName(0, "TreeClosedFolderIcon.png");
			this.contentImageList.Images.SetKeyName(1, "TreeOpenFolderIcon.png");
			this.contentImageList.Images.SetKeyName(2, "TreeDocIcon.png");
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlToolStripMenuItem,
            this.viewToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
			this.menuStrip1.Size = new System.Drawing.Size(790, 24);
			this.menuStrip1.TabIndex = 7;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// controlToolStripMenuItem
			// 
			this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshAppCodeToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
			this.controlToolStripMenuItem.Size = new System.Drawing.Size(59, 22);
			this.controlToolStripMenuItem.Text = "Control";
			// 
			// refreshAppCodeToolStripMenuItem
			// 
			this.refreshAppCodeToolStripMenuItem.Name = "refreshAppCodeToolStripMenuItem";
			this.refreshAppCodeToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.refreshAppCodeToolStripMenuItem.Text = "Refresh App Code";
			this.refreshAppCodeToolStripMenuItem.Click += new System.EventHandler(this.refreshAppCodeToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugConsoleToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
			this.viewToolStripMenuItem.Text = "View";
			// 
			// debugConsoleToolStripMenuItem
			// 
			this.debugConsoleToolStripMenuItem.Name = "debugConsoleToolStripMenuItem";
			this.debugConsoleToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.debugConsoleToolStripMenuItem.Text = "Debug Console";
			this.debugConsoleToolStripMenuItem.Click += new System.EventHandler(this.debugConsoleToolStripMenuItem_Click);
			// 
			// xToolStripMenuItem
			// 
			this.xToolStripMenuItem.Name = "xToolStripMenuItem";
			this.xToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
			// 
			// xToolStripMenuItem1
			// 
			this.xToolStripMenuItem1.Name = "xToolStripMenuItem1";
			this.xToolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
			// 
			// xToolStripMenuItem2
			// 
			this.xToolStripMenuItem2.Name = "xToolStripMenuItem2";
			this.xToolStripMenuItem2.Size = new System.Drawing.Size(32, 19);
			// 
			// xToolStripMenuItem3
			// 
			this.xToolStripMenuItem3.Name = "xToolStripMenuItem3";
			this.xToolStripMenuItem3.Size = new System.Drawing.Size(32, 19);
			// 
			// statusBar
			// 
			this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
			this.statusBar.Location = new System.Drawing.Point(0, 428);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(790, 22);
			this.statusBar.TabIndex = 8;
			this.statusBar.Text = "statusStrip1";
			// 
			// statusLabel
			// 
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(39, 17);
			this.statusLabel.Text = "Ready";
			// 
			// typeTabs
			// 
			this.typeTabs.Controls.Add(tabPageContent);
			this.typeTabs.Controls.Add(tabPageApps);
			this.typeTabs.Dock = System.Windows.Forms.DockStyle.Left;
			this.typeTabs.Location = new System.Drawing.Point(0, 24);
			this.typeTabs.Name = "typeTabs";
			this.typeTabs.SelectedIndex = 0;
			this.typeTabs.Size = new System.Drawing.Size(200, 404);
			this.typeTabs.TabIndex = 9;
			// 
			// split
			// 
			this.split.Location = new System.Drawing.Point(200, 24);
			this.split.Name = "split";
			this.split.Size = new System.Drawing.Size(3, 404);
			this.split.TabIndex = 10;
			this.split.TabStop = false;
			// 
			// webView2Control
			// 
			this.webView2Control.BackColor = System.Drawing.SystemColors.Desktop;
			this.webView2Control.CreationProperties = null;
			this.webView2Control.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webView2Control.Location = new System.Drawing.Point(203, 24);
			this.webView2Control.Name = "webView2Control";
			this.webView2Control.Size = new System.Drawing.Size(587, 404);
			this.webView2Control.TabIndex = 11;
			this.webView2Control.ZoomFactor = 1D;
			this.webView2Control.CoreWebView2InitializationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs>(this.WebView2Control_CoreWebView2InitializationCompleted);
			this.webView2Control.WebMessageReceived += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs>(this.webView2Control_WebMessageReceived);
			// 
			// BrowserForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(790, 450);
			this.Controls.Add(this.webView2Control);
			this.Controls.Add(this.split);
			this.Controls.Add(this.typeTabs);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "BrowserForm";
			this.Text = "ThreeHost";
			this.Shown += new System.EventHandler(this.BrowserForm_Shown);
			this.Resize += new System.EventHandler(this.Form_Resize);
			contentTabTools.ResumeLayout(false);
			contentTabTools.PerformLayout();
			tabPageApps.ResumeLayout(false);
			tabPageApps.PerformLayout();
			appTabTools.ResumeLayout(false);
			appTabTools.PerformLayout();
			tabPageContent.ResumeLayout(false);
			tabPageContent.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			this.typeTabs.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.webView2Control)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem3;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.TabControl typeTabs;
		private System.Windows.Forms.Splitter split;
		private Microsoft.Web.WebView2.WinForms.WebView2 webView2Control;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.TreeView contentTree;
		private System.Windows.Forms.ToolStripButton removeContentFolderButton;
		private System.Windows.Forms.ToolStripButton removeAppButton;
		private System.Windows.Forms.CheckedListBox appList;
		private System.Windows.Forms.ToolStripMenuItem debugConsoleToolStripMenuItem;
		private System.Windows.Forms.ImageList contentImageList;
		private System.Windows.Forms.ToolStripMenuItem refreshAppCodeToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel statusLabel;
	}
}

