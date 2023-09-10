using System;
using System.Collections.Generic;

public class ExternalId
{
    public string? kpHD { get; set; }
    public string? imdb { get; set; }
    public int? tmdb { get; set; }
}

public class Name
{
    public string? name { get; set; }
    public string? language { get; set; }
    public string? type { get; set; }
}

public class Rating
{
    public double? kp { get; set; }
    public double? imdb { get; set; }
    public double? tmdb { get; set; }
    public double? filmCritics { get; set; }
    public double? russianFilmCritics { get; set; }
    public double? await { get; set; }
}
public class Votes
{
    public int? kp { get; set; }
    public int? imdb { get; set; }
    public int? tmdb { get; set; }
    public int? filmCritics { get; set; }
    public int? russianFilmCritics { get; set; }
    public int? await { get; set; }
}

public class Logo
{
    public string? url { get; set; }
}

public class Poster
{
    public string? url { get; set; }
    public string? previewUrl { get; set; }
}

public class Backdrop
{
    public string? url { get; set; }
    public string? previewUrl { get; set; }
}

public class Trailer
{
    public string? url { get; set; }
    public string? name { get; set; }
    public string? site { get; set; }
    public string? type { get; set; }
    public int? size { get; set; }
}

public class Videos
{
    public List<Trailer>? trailers { get; set; }
    public List<Trailer>? teasers { get; set; }
}

public class Genre
{
    public string? name { get; set; }
}

public class Country
{
    public string? name { get; set; }
}

public class Person
{
    public int? id { get; set; }
    public string? photo { get; set; }
    public string? name { get; set; }
    public string? enName { get; set; }
    public string? description { get; set; }
    public string? profession { get; set; }
    public string? enProfession { get; set; }
}

public class ReviewInfo
{
    public int? count { get; set; }
    public int? positiveCount { get; set; }
    public string? percentage { get; set; }
}

public class SeasonsInfo
{
    public int? number { get; set; }
    public int? episodesCount { get; set; }
}

public class Budget
{
    public int? value { get; set; }
    public string? currency { get; set; }
}

public class Fees
{
    public Budget? world { get; set; }
    public Budget? russia { get; set; }
    public Budget? usa { get; set; }
}

public class Premiere
{
    public string? country { get; set; }
    public DateTime? world { get; set; }
    public DateTime? russia { get; set; }
    public string? digital { get; set; }
    public DateTime? cinema { get; set; }
    public string? bluray { get; set; }
    public string? dvd { get; set; }
}

public class SimilarMovie
{
    public int? id { get; set; }
    public string? name { get; set; }
    public string? enName { get; set; }
    public string? alternativeName { get; set; }
    public string? type { get; set; }
    public Poster? poster { get; set; }
}

public class SequelAndPrequel
{
    public int? id { get; set; }
    public string? name { get; set; }
    public string? enName { get; set; }
    public string? alternativeName { get; set; }
    public string? type { get; set; }
    public Poster? poster { get; set; }
}

public class WatchabilityItem
{
    public string? name { get; set; }
    public Logo? logo { get; set; }
    public string? url { get; set; }
}

public class ReleaseYear
{
    public int? start { get; set; }
    public int? end { get; set; }
}

public class Fact
{
    public string? value { get; set; }
    public string? type { get; set; }
    public bool? spoiler { get; set; }
}

public class ImagesInfo
{
    public int? postersCount { get; set; }
    public int? backdropsCount { get; set; }
    public int? framesCount { get; set; }
}

public class ProductionCompany
{
    public string? name { get; set; }
    public string? url { get; set; }
    public string? previewUrl { get; set; }
}

public class Movie
{
    public int? id { get; set; }
    public ExternalId? externalId { get; set; }
    public string? name { get; set; }
    public string? alternativeName { get; set; }
    public string? enName { get; set; }
    public List<Name>? names { get; set; }
    public string? type { get; set; }
    public int? typeNumber { get; set; }
    public int? year { get; set; }
    public string? description { get; set; }
    public string? shortDescription { get; set; }
    public string? slogan { get; set; }
    public string? status { get; set; }
    public Rating? rating { get; set; }
    public Votes? votes { get; set; }
    public int? movieLength { get; set; }
    public string? ratingMpaa { get; set; }
    public int? ageRating { get; set; }
    public Logo? logo { get; set; }
    public Poster? poster { get; set; }
    public Backdrop? backdrop { get; set; }
    public Videos? videos { get; set; }
    public List<Genre>? genres { get; set; }
    public List<Country>? countries { get; set; }
    public List<Person>? persons { get; set; }
    public ReviewInfo? reviewInfo { get; set; }
    public List<SeasonsInfo>? seasonsInfo { get; set; }
    public Budget? budget { get; set; }
    public Fees? fees { get; set; }
    public Premiere? premiere { get; set; }
    public List<SimilarMovie>? similarMovies { get; set; }
    public List<SequelAndPrequel>? sequelsAndPrequels { get; set; }
    public WatchabilityItem? watchability { get; set; }
    public List<ReleaseYear>? releaseYears { get; set; }
    public int? top10 { get; set; }
    public int? top250 { get; set; }
    public bool? ticketsOnSale { get; set; }
    public int? totalSeriesLength { get; set; }
    public int? seriesLength { get; set; }
    public bool? isSeries { get; set; }
    public List<Audience>? audience { get; set; }
    public List<Fact>? facts { get; set; }
    public ImagesInfo? imagesInfo { get; set; }
    public List<ProductionCompany>? productionCompanies { get; set; }
}

public class Audience
{
    public int? count { get; set; }
    public string? country { get; set; }
}

public class Root
{
    public List<Movie>? docs { get; set; }
    public int? total { get; set; }
    public int? limit { get; set; }
    public int? page { get; set; }
    public int? pages { get; set; }
}
