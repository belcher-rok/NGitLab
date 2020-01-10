﻿using System;
using System.Linq;
using System.Runtime.Serialization;

namespace NGitLab.Models
{
    [DataContract]
    public sealed class BlameCommit : IEquatable<BlameCommit>
    {
        [DataMember(Name = "id")]
        public Sha1 Id { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "parent_ids")]
        public Sha1[] Parents { get; set; }

        [DataMember(Name = "authored_date")]
        public DateTime AuthoredDate { get; set; }

        [DataMember(Name = "author_name")]
        public string AuthorName { get; set; }

        [DataMember(Name = "author_email")]
        public string AuthorEmail { get; set; }

        [DataMember(Name = "committed_date")]
        public DateTime CommittedDate { get; set; }

        [DataMember(Name = "committer_name")]
        public string CommitterName { get; set; }

        [DataMember(Name = "committer_email")]
        public string CommitterEmail { get; set; }

        public bool Equals(BlameCommit other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Id.Equals(other.Id)
                && string.Equals(Message, other.Message, StringComparison.Ordinal) 
                && !ReferenceEquals(Parents, null) && !ReferenceEquals(null, other.Parents) && Parents.SequenceEqual(other.Parents)
                && AuthoredDate.Equals(other.AuthoredDate) 
                && string.Equals(AuthorName, other.AuthorName, StringComparison.Ordinal) 
                && string.Equals(AuthorEmail, other.AuthorEmail, StringComparison.OrdinalIgnoreCase) 
                && CommittedDate.Equals(other.CommittedDate) 
                && string.Equals(CommitterName, other.CommitterName, StringComparison.Ordinal)
                && string.Equals(CommitterEmail, other.CommitterEmail, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            return obj is BlameCommit commit && Equals(commit);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (Message != null ? StringComparer.Ordinal.GetHashCode(Message) : 0);
                hashCode = (hashCode * 397) ^ (Parents != null ? Parents.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ AuthoredDate.GetHashCode();
                hashCode = (hashCode * 397) ^ (AuthorName != null ? StringComparer.Ordinal.GetHashCode(AuthorName) : 0);
                hashCode = (hashCode * 397) ^ (AuthorEmail != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(AuthorEmail) : 0);
                hashCode = (hashCode * 397) ^ CommittedDate.GetHashCode();
                hashCode = (hashCode * 397) ^ (CommitterName != null ? StringComparer.Ordinal.GetHashCode(CommitterName) : 0);
                hashCode = (hashCode * 397) ^ (CommitterEmail != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(CommitterEmail) : 0);
                return hashCode;
            }
        }
    }
}