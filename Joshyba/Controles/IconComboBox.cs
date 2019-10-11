using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Joshyba.Controles
{
    [ToolboxBitmap(typeof(ComboBox))]
    public partial class IconComboBox : ComboBox
    {
        public enum IconComboItemCollectionChangeType
        {
            ItemAdded,
            ItemRemoved,
            ItemInserted,
            CollectionCleared
        }

        /// <summary>
        ///  Object representing an entry in the IconComboBox.
        ///  </summary>
        /// <remarks>Implements IEquatable for searching and sorting the IconComboItemCollection.</remarks>
        public class IconComboItem : IEquatable<IconComboBox.IconComboItem>
        {
            private Icon m_Icon;

            private string m_Data;

            private string m_DisplayText;

            private bool m_isDivider;

            /// <summary>
            ///  The image to be displayed next to the text for this combo box item.
            ///  </summary>
            /// <value>The icon to be displayed</value>
            /// <returns>The icon currently being displayed</returns>
            /// <remarks></remarks>
            public Icon ItemImage
            {
                get
                {
                    return this.m_Icon;
                }
                set
                {
                    this.m_Icon = value;
                }
            }

            public string Data
            {
                get
                {
                    return this.m_Data;
                }
                set
                {
                    this.m_Data = value;
                }
            }

            /// <summary>
            ///  What to display for this item.
            ///  </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public string DisplayText
            {
                get
                {
                    return this.m_DisplayText;
                }
                set
                {
                    this.m_DisplayText = value;
                }
            }

            public bool IsDivider
            {
                get
                {
                    return this.m_isDivider;
                }
                internal set
                {
                    this.m_isDivider = value;
                }
            }

            public IconComboItem()
            {
            }

            /// <summary>
            ///  Create a new IconComboItem with the specified values
            ///  </summary>
            /// <param name="argText">The text to display in the combo box</param>
            /// <param name="argData">The string representing this IconComboItem's data</param>
            /// <remarks></remarks>
            public IconComboItem(string argText, string argData)
            {
                this.m_DisplayText = argText;
                this.m_Data = argData;
            }

            public static bool operator ==(IconComboBox.IconComboItem item1, IconComboBox.IconComboItem item2)
            {
                return String.Compare(item1.Data, item2.Data, false) == 0;
            }

            public static bool operator !=(IconComboBox.IconComboItem item1, IconComboBox.IconComboItem item2)
            {
                return String.Compare(item1.Data, item2.Data, false) != 0;
            }

            public bool Equals(IconComboBox.IconComboItem other)
            {
                return String.Compare(this.m_Data, other.Data, false) == 0;
            }
        }

        public class IconComboItemCollection
        {
            internal delegate void CollectionChangedEventHandler(object sender, IconComboBox.IconComboItemCollectionChangedEventArgs e);

            private List<IconComboBox.IconComboItem> m_List;

            private IconComboBox.IconComboItemCollection.CollectionChangedEventHandler CollectionChangedEvent;

            internal event IconComboBox.IconComboItemCollection.CollectionChangedEventHandler CollectionChanged
            {
                [DebuggerNonUserCode]
                [MethodImpl(MethodImplOptions.Synchronized)]
                add
                {
                    this.CollectionChangedEvent = (IconComboBox.IconComboItemCollection.CollectionChangedEventHandler)Delegate.Combine(this.CollectionChangedEvent, value);
                }
                [DebuggerNonUserCode]
                [MethodImpl(MethodImplOptions.Synchronized)]
                remove
                {
                    this.CollectionChangedEvent = (IconComboBox.IconComboItemCollection.CollectionChangedEventHandler)Delegate.Remove(this.CollectionChangedEvent, value);
                }
            }

            public int Count
            {
                get
                {
                    return this.m_List.Count;
                }
            }

            /// <summary>
            ///  Gets the IconComboItem at the specfied index
            ///  </summary>
            /// <param name="index">The index of the IconComboItem to return</param>
            /// <value></value>
            /// <returns>The IconComboItem at the specified index, or nothing if the index is out of range.</returns>
            /// <remarks></remarks>
            public IconComboBox.IconComboItem this[int index]
            {
                get
                {
                    if (index < this.m_List.Count)
                    {
                        return this.m_List[index];
                    }
                    return null;
                }
            }

            public IconComboItemCollection()
            {
                this.m_List = new List<IconComboBox.IconComboItem>();
            }

            public int Add(IconComboBox.IconComboItem argItem)
            {
                this.m_List.Add(argItem);
                IconComboBox.IconComboItemCollection.CollectionChangedEventHandler collectionChangedEvent = this.CollectionChangedEvent;
                checked
                {
                    if (collectionChangedEvent != null)
                    {
                        collectionChangedEvent(this, new IconComboBox.IconComboItemCollectionChangedEventArgs(this.m_List.Count - 1, IconComboBox.IconComboItemCollectionChangeType.ItemAdded, argItem));
                    }
                    return this.m_List.Count - 1;
                }
            }

            /// <summary>
            ///  Insert the specified IconComboItem at the specified index.
            ///  </summary>
            /// <param name="idx"></param>
            /// <param name="argItem"></param>
            /// <returns></returns>
            /// <remarks></remarks>
            public bool Insert(int idx, IconComboBox.IconComboItem argItem)
            {
                this.m_List.Insert(idx, argItem);
                if (this.m_List[idx] == argItem)
                {
                    IconComboBox.IconComboItemCollection.CollectionChangedEventHandler collectionChangedEvent = this.CollectionChangedEvent;
                    if (collectionChangedEvent != null)
                    {
                        collectionChangedEvent(this, new IconComboBox.IconComboItemCollectionChangedEventArgs(idx, IconComboBox.IconComboItemCollectionChangeType.ItemInserted, argItem));
                    }
                    return true;
                }
                return false;
            }

            public bool Remove(IconComboBox.IconComboItem argItem)
            {
                if (this.m_List.Remove(argItem))
                {
                    IconComboBox.IconComboItemCollection.CollectionChangedEventHandler collectionChangedEvent = this.CollectionChangedEvent;
                    if (collectionChangedEvent != null)
                    {
                        collectionChangedEvent(this, new IconComboBox.IconComboItemCollectionChangedEventArgs(0, IconComboBox.IconComboItemCollectionChangeType.ItemRemoved, argItem));
                    }
                    return true;
                }
                return false;
            }

            public void Clear()
            {
                this.m_List.Clear();
                IconComboBox.IconComboItemCollection.CollectionChangedEventHandler collectionChangedEvent = this.CollectionChangedEvent;
                if (collectionChangedEvent != null)
                {
                    collectionChangedEvent(this, new IconComboBox.IconComboItemCollectionChangedEventArgs(-1, IconComboBox.IconComboItemCollectionChangeType.CollectionCleared, null));
                }
            }

            /// <summary>
            ///  Determine if the collection contains the specified IconComboItem, using the 
            ///  <see>IconComboItem.Equals</see> method for comparison.
            ///  </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            /// <remarks></remarks>
            public bool Contains(IconComboBox.IconComboItem item)
            {
                return this.m_List.Contains(item);
            }

            public int IndexOf(IconComboBox.IconComboItem item)
            {
                return this.m_List.IndexOf(item);
            }
        }

        /// <summary>
        ///  These args are used in events indicating that the IconComboItemCollection has been
        ///  changed.  This class can only be used by the IconComboBox.
        ///  </summary>
        /// <remarks></remarks>
        internal class IconComboItemCollectionChangedEventArgs : EventArgs
        {
            private IconComboBox.IconComboItemCollectionChangeType m_ChangeType;

            private IconComboBox.IconComboItem m_ChangedItem;

            private int m_ChangedIndex;

            /// <summary>
            ///  Indicates how the IconComboItemCollection was changed - add, delete, remove, or clear.
            ///  </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public IconComboBox.IconComboItemCollectionChangeType ChangeType
            {
                get
                {
                    return this.m_ChangeType;
                }
            }

            public IconComboBox.IconComboItem ChangedItem
            {
                get
                {
                    return this.m_ChangedItem;
                }
            }

            /// <summary>
            ///  The index of the changed item in the IconComboItemCollection.
            ///  </summary>
            /// <value></value>
            /// <returns></returns>
            /// <remarks></remarks>
            public int ChangedIndex
            {
                get
                {
                    return this.m_ChangedIndex;
                }
            }

            public IconComboItemCollectionChangedEventArgs(int argidx, IconComboBox.IconComboItemCollectionChangeType argType, IconComboBox.IconComboItem argItem)
            {
                this.m_ChangeType = argType;
                this.m_ChangedItem = argItem;
                this.m_ChangedIndex = argidx;
            }
        }

        private IContainer components;

        [AccessedThroughProperty("ToolTip1")]
        private ToolTip _ToolTip1;

        private IconComboBox.IconComboItem m_CurrentItem;

        private IconComboBox.IconComboItemCollection m_IconComboItemList;

        internal virtual ToolTip ToolTip1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ToolTip1;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolTip1 = value;
            }
        }

        /// <summary>
        ///  Get or set the tooltip text to be shown in the tooltip over the
        ///  combobox.
        ///  </summary>
        /// <value>The new string to display in the tooltip.</value>
        /// <returns>The string currently being displayed in the tooltip.</returns>
        /// <remarks>This string defaults to the Data.ToString value when an item
        ///  in the ComboBox is selected.</remarks>
        public string ToolTipText
        {
            get
            {
                return this.ToolTip1.GetToolTip(this);
            }
            set
            {
                this.ToolTip1.SetToolTip(this, value);
            }
        }

        public new IconComboBox.IconComboItemCollection Items
        {
            get
            {
                return this.m_IconComboItemList;
            }
        }

        /// <summary>
        ///  Gets the IconComboItem object for the currently selected item in the dropdown.
        ///  </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public new IconComboBox.IconComboItem SelectedItem
        {
            get
            {
                if (this.SelectedIndex >= 0)
                {
                    return this.m_IconComboItemList[this.SelectedIndex];
                }
                return null;
            }
            set
            {
                this.m_CurrentItem = value;
            }
        }

        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            this.ToolTip1 = new ToolTip(this.components);
            this.SuspendLayout();
            this.ResumeLayout(false);
        }

        public IconComboBox()
        {
            this.InitializeComponent();
            this.m_IconComboItemList = new IconComboBox.IconComboItemCollection();
            this.m_IconComboItemList.CollectionChanged += new IconComboBox.IconComboItemCollection.CollectionChangedEventHandler(this.m_IconComboItemList_CollectionItemsChanged);
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ExpCombo_DropDownStyleChanged(object sender, EventArgs e)
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        protected override void OnFontChanged(EventArgs e)
        {
            if (this.Font.SizeInPoints > 12f)
            {
                this.Font = new Font(this.Font.FontFamily, 12f, this.Font.Style);
            }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (this.SelectedIndex < 0)
            {
                return;
            }
            checked
            {
                if (this.SelectedIndex < this.m_IconComboItemList.Count)
                {
                    if (this.m_IconComboItemList[this.SelectedIndex].IsDivider)
                    {
                        if (this.SelectedIndex > 0)
                        {
                            this.SelectedIndex--;
                            this.m_CurrentItem = this.m_IconComboItemList[this.SelectedIndex];
                        }
                        else if (this.SelectedIndex < this.m_IconComboItemList.Count - 1)
                        {
                            this.SelectedIndex++;
                            this.m_CurrentItem = this.m_IconComboItemList[this.SelectedIndex];
                        }
                    }
                    else
                    {
                        this.m_CurrentItem = this.m_IconComboItemList[this.SelectedIndex];
                        base.OnSelectedIndexChanged(e);
                    }
                    this.ToolTip1.SetToolTip(this, this.m_CurrentItem.Data);
                }
            }
        }

        /// <summary>
        ///  Draws an IconComboBox item into the ComboBox in the area specified by the DrawItemEventArgs.
        ///  </summary>
        /// <param name="e">Event argument specifying which item to draw and where to draw it.</param>
        /// <remarks></remarks>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            Rectangle bounds = e.Bounds;
            checked
            {
                if (e.Index > -1 && e.Index < this.Items.Count && e.Index < this.m_IconComboItemList.Count)
                {
                    IconComboBox.IconComboItem iconComboItem = this.m_IconComboItemList[e.Index];
                    if (iconComboItem != null)
                    {
                        if (iconComboItem.IsDivider)
                        {
                            float x = (float)(bounds.X + 10);
                            float num = Convert.ToSingle(unchecked((double)bounds.Y + (double)bounds.Height / 2.0 + 1.0));
                            float x2 = (float)(bounds.Width - 10);
                            float y = num;
                            e.Graphics.DrawLine(Pens.Black, x, num, x2, y);
                            num = Convert.ToSingle(unchecked((double)bounds.Y + (double)bounds.Height / 2.0 - 1.0));
                            y = num;
                            e.Graphics.DrawLine(Pens.Black, x, num, x2, y);
                        }
                        else
                        {
                            string displayText = iconComboItem.DisplayText;
                            string data = iconComboItem.Data;
                            Icon itemImage = iconComboItem.ItemImage;
                            Rectangle targetRect = new Rectangle(bounds.Left + 1, bounds.Top + 1, this.ItemHeight, this.ItemHeight);
                            if (itemImage != null)
                            {
                                e.Graphics.DrawIcon(itemImage, targetRect);
                            }
                            Size size = targetRect.Size;
                            Rectangle r = new Rectangle(bounds.Left + size.Width + 3, bounds.Top, bounds.Width - size.Width - 3, bounds.Height);
                            StringFormat stringFormat = new StringFormat();
                            stringFormat.LineAlignment = StringAlignment.Center;
                            e.Graphics.DrawString(displayText, e.Font, new SolidBrush(e.ForeColor), r, stringFormat);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error, the selected item is nothing");
                    }
                }
                base.OnDrawItem(e);
            }
        }

        public int AddDivider()
        {
            IconComboBox.IconComboItem iconComboItem = new IconComboBox.IconComboItem();
            iconComboItem.DisplayText = "";
            iconComboItem.IsDivider = true;
            return this.Items.Add(iconComboItem);
        }

        private void m_IconComboItemList_CollectionItemsChanged(object sender, IconComboBox.IconComboItemCollectionChangedEventArgs e)
        {
            if (e.ChangeType == IconComboBox.IconComboItemCollectionChangeType.ItemAdded)
            {
                base.Items.Add(e.ChangedItem.DisplayText);
            }
            else if (e.ChangeType == IconComboBox.IconComboItemCollectionChangeType.ItemInserted)
            {
                base.Items.Insert(e.ChangedIndex, e.ChangedItem.DisplayText);
            }
            else if (e.ChangeType == IconComboBox.IconComboItemCollectionChangeType.ItemRemoved)
            {
                base.Items.Remove(e.ChangedItem.DisplayText);
            }
            else if (e.ChangeType == IconComboBox.IconComboItemCollectionChangeType.CollectionCleared)
            {
                base.Items.Clear();
            }
        }
    }
}
