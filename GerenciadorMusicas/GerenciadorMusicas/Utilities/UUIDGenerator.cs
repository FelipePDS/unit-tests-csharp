using System;

namespace GerenciadorMusicas.Utilities
{
    public static class UUIDGenerator
    {
        public static Guid GenerateUUID()
        {
            return Guid.NewGuid();
        }

        public static bool IsValidUUID(Guid uuid)
        {
            return uuid != Guid.Empty && Guid.TryParse(uuid.ToString(), out _);
        }
    }
}
