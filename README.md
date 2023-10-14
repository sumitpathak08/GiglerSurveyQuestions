# GiglerSurveyQuestions
I was asked to do practical work of Getting 5 Random Question for Gigler Survey for Users in an interview which was to do on DotNetCore Web API with SQL server database.
SQL Database Schema
CREATE TABLE [dbo].[Tbl_Survey_Question](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Question] [varchar](100) NOT NULL,
	[SimilarQId] [int] NULL	
 CONSTRAINT [PK_Tbl_Survey_Question] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Tbl_Survey_Question]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Survey_Question_Tbl_Survey_Question] FOREIGN KEY([SimilarQId])
REFERENCES [dbo].[Tbl_Survey_Question] ([Id])
GO

ALTER TABLE [dbo].[Tbl_Survey_Question] CHECK CONSTRAINT [FK_Tbl_Survey_Question_Tbl_Survey_Question]
GO

----------------------------------------------------------------------------------------------------
Data Entries in the above table
Id	Question	                  SimilarQId	
1	  How are you feeling today?	1		
2  	How are you today?	        1	
3	  What is your interest?	    3	
4	  What are your hobbies?	    3


GiglerSurveyQuestions - Get 5 Random Question for Survey in DotNetCore

A platform called Gigler conducts online surveys where Users can give their opinion by
selecting answersfor a number of questions.
A group of questions is presented randomly to the User from a larger pool of questions that
they have. In other words, the User does not see allthe questions but only a group of them
that israndomly selected.
Within this pool of questions, we have two that have almost the same meaning. Showing
one of themto the User means that there is no pointin showing the other because it will be
as if they are replying to the same question.
i.e.
1. How are you feeling today?
2. How are you today?
3. What is your interest?
4. What are your hobbies?

The Goal

We need to present 5 randomly selected questions to user and make sure that if one of
these questionsis presented the other one will not appear to avoid asking them to reply to
the same thing twice. Questions must be selected randomly so that users get different
questionsin case they do survey multiple times.

