namespace Jmk.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Selection<TItem>
    {
        // Constructors

        public List<TItem> Items { get; } = new List<TItem>();

        // Private fields

        private int UpdateCount;
        private bool Updated;

        // Public properties

        public bool IsEmpty => !Items.Any();

        // Public events

        public event EventHandler Changed;

        // Public methods

        public void Add(TItem item)
        {
            if (Items.Contains(item))
                return;
            Items.Add(item);
            OnChanged();
        }

        public void AddRange(IEnumerable<TItem> items)
        {
            items = items.Where(p => !Items.Contains(p)).ToList();
            if (IsEmpty)
                return;
            Items.AddRange(items);
            OnChanged();
        }

        public void BeginUpdate() => UpdateCount++;

        public void Clear()
        {
            if (IsEmpty)
                return;
            Items.Clear();
            OnChanged();
        }

        public void EndUpdate()
        {
            if (--UpdateCount > 0 || !Updated)
                return;
            Updated = false;
            OnChanged();
        }

        public void ForEach(Action<TItem> action)
        {
            foreach (var item in Items)
                action(item);
        }

        public void Remove(TItem item)
        {
            if (!Items.Contains(item))
                return;
            Items.Remove(item);
            OnChanged();
        }

        public void Set(IEnumerable<TItem> items)
        {
            Items.Clear();
            Items.AddRange(items);
            OnChanged();
        }

        public override string ToString() => IsEmpty ? string.Empty : Items.Select(p => p.ToString()).Aggregate((s, t) => $"{s}, {t}");

        // Protected methods

        protected bool? GetBool(Func<TItem, bool> f)
        {
            if (IsEmpty || f == null)
                return default;
            bool first = f(Items.First());
            return Items.FirstOrDefault(p => !Equals(f(p), first)) != null
                ? (bool?)null
                : first;
        }

        protected TProperty GetProperty<TProperty>(Func<TItem, TProperty> f) where TProperty : IEquatable<TProperty>
        {
            if (IsEmpty || f == null)
                return default;
            TProperty first = f(Items.First());
            return Items.FirstOrDefault(p => !Equals(f(p), first)) != null
                ? default
                : first;
        }

        protected virtual void OnChanged()
        {
            if (UpdateCount > 0)
                Updated = true;
            else
                Changed?.Invoke(this, EventArgs.Empty);
        }

        protected void SetProperty(Action<TItem> set) => ForEach(set);
    }
}
