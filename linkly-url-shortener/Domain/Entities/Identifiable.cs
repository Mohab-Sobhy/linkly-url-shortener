using System;

namespace linkly_url_shortener.Domain.Entities;

public interface Identifiable<T>
{
    T Id { get; set; }
}
