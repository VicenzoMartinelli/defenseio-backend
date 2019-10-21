using System;

namespace DefenseIO.Infra.Shared
{
  public abstract class Entity : IEquatable<Entity>
  {
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    protected Entity(Guid id)
    {
      Id = id;
      CreatedAt = DateTime.UtcNow;
      UpdatedAt = DateTime.UtcNow;
    }

    protected Entity()
    {
      CreatedAt = DateTime.UtcNow;
      UpdatedAt = DateTime.UtcNow;
    }

    protected Entity(DateTime data)
    {
      CreatedAt = data;
      UpdatedAt = data;
    }

    protected Entity(Guid id, DateTime data)
    {
      Id = id;
      CreatedAt = data;
      UpdatedAt = data;
    }

    public bool Equals(Entity other)
    {
      return Id.Equals(other.Id);
    }
  }
}
