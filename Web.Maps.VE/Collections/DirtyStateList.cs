/* ----------------------------------------------------------------------------------- */
/* Copyright (C) Simplovation LLC (http://Simplovation.com) 2014. All rights reserved. */
/* Licensing information available at http://webmapsve.codeplex.com                    */
/* ----------------------------------------------------------------------------------- */
using System.Collections.Generic;
using Simplovation.Web.Maps.VE.Interfaces;
using System;

namespace Simplovation.Web.Maps.VE.Collections
{
    public class DirtyStateList<T> : List<T>
    {
        #region Supported Methods

        public new void Add(T value)
        {
            this._IsDirty = true;
            base.Add(value);
        }

        public new void Remove(T value)
        {
            /*
            if (value is IClientID)
            {
                if (_IDListToRemove.Length != 0) _IDListToRemove += "|";
                _IDListToRemove += ((IClientID)value).ClientID;
            }
            */
            this.AddIDListToRemove(value);

            /*
            if (this.Contains(value))
            {
                int index = this.IndexOf(value);
                if (!string.IsNullOrEmpty(this._ItemIndexesToRemove)) { this._ItemIndexesToRemove += "|"; }
                this._ItemIndexesToRemove += index.ToString();
            }
            */
            this.AddItemIndexesToRemove(value);

            this._IsDirty = true;

            base.Remove(value);
        }

        public new void RemoveAt(int index)
        {
            this.AddIDListToRemove(this[index]);
            this.AddItemIndexesToRemove(this[index]);
            base.RemoveAt(index);
        }

        public new void Clear()
        {
            _IDListToRemove = "";
            this._ItemIndexesToRemove = string.Empty;
            this._IsDirty = true;
            this._WasCleared = true;
            base.Clear();
        }

        public new void RemoveRange(int index, int count)
        {
            for (var i = index; i < count; i++)
            {
                this.AddIDListToRemove(this[i]);
                this.AddItemIndexesToRemove(this[i]);
            }
            base.RemoveRange(index, count);
        }

        public new int RemoveAll(System.Predicate<T> match)
        {
            foreach (T obj in this.FindAll(match))
            {
                this.AddIDListToRemove(obj);
                this.AddItemIndexesToRemove(obj);
            }
            return base.RemoveAll(match);
        }

        #endregion

        #region Dirty State Stuff

        private bool _IsDirty = false;
        public bool IsDirty
        {
            get
            {
                return true;
                //return _IsDirty;
            }
            set { _IsDirty = value; }
        }

        private bool _WasCleared = false;
        public bool WasCleared
        {
            get { return _WasCleared; }
            set { _WasCleared = value; }
        }

        public void MarkClean()
        {
            this._IsDirty = false;
        }

        private void AddItemIndexesToRemove(T obj)
        {
            if (this.Contains(obj))
            {
                int index = this.IndexOf(obj);

                if (!string.IsNullOrEmpty(this._ItemIndexesToRemove))
                    this._ItemIndexesToRemove += "|";

                this._ItemIndexesToRemove += index.ToString();
            }
        }

        private void AddIDListToRemove(T obj)
        {
            if (obj is IClientID)
            {
                string id = ((IClientID)obj).ClientID;

                if (this._IDListToRemove.Length != 0)
                    this._IDListToRemove += "|";

                this._IDListToRemove += id;
            }
        }

        private string _ItemIndexesToRemove = string.Empty;
        public string ItemIndexesToRemove
        {
            get { return this._ItemIndexesToRemove; }
        }

        private string _IDListToRemove = "";
        public string IDListToRemove
        {
            get { return _IDListToRemove; }
        }

        #endregion
    }
}
