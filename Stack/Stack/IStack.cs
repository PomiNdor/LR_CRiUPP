using System;
using System.Collections.Generic;

﻿namespace CRiUPP_lab_01
{
  public interface IStack<T> : IEnumerable<T>, ICloneable
  {
    int Count { get; }
    void Push(T item);
    T Peek();
    T Pop();
    void Clear();
    bool Contains(T item);
  }
}
