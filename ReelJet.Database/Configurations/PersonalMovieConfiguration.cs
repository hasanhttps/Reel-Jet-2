using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReelJet.Database.Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ReelJet.Database.Configurations;

public class PersonalMovieConfiguration : IEntityTypeConfiguration<PersonalMovie> {
    public void Configure(EntityTypeBuilder<PersonalMovie> builder) {

        builder.Property(m => m.MovieLink).IsRequired();

        // Relations

        builder.HasMany(m => m.WatchList).WithOne(p => p.PersonalMovie).HasForeignKey(p => p.PersonalMovieId);
        builder.HasMany(m => m.HistoryList).WithOne(p => p.PersonalMovie).HasForeignKey(p => p.PersonalMovieId);
        builder.HasMany(m => m.CommentsMovies).WithOne(p => p.PersonalMovie).HasForeignKey(p => p.PersonalMovieId);
    }
}