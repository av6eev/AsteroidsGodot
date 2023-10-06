﻿using System.Collections.Generic;
using Asteroids.Scripts.Utilities.Interfaces;

namespace Asteroids.Scripts.Utilities;

public class PresentersEngine : IPresenter
{
    private readonly List<IPresenter> _presenters = new();
    
    public void Add(IPresenter presenter) => _presenters.Add(presenter);

    public void AddRange(List<IPresenter> presenters) => _presenters.AddRange(presenters);
    
    public void Activate()
    {
        foreach (var presenter in _presenters)
        {
            presenter.Activate();
        }
    }

    public void Deactivate()
    {
        foreach (var presenter in _presenters)
        {
            presenter.Deactivate();
        }
    }
    
    public void Clear() => _presenters.Clear();

    public List<IPresenter> GetAll() => _presenters;
    
    public void Remove(IPresenter presenter)
    {
        if (!_presenters.Contains(presenter)) return;
            
        presenter.Deactivate();
        _presenters.Remove(presenter);
    }
}