<!DOCTYPE html>
<html>

<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <link rel="stylesheet" href="https://stackedit.io/style.css" />
</head>

<body class="stackedit">
  <div class="stackedit__html"><blockquote>
<p>Requirements</p>
<p>App Name: MoVenture</p>
</blockquote>
<h3 id="models">Models</h3>
<ol>
<li><i>Movie:</i> Id, Title, List&lt;CategoryId&gt;, Description, LaunchDate, PictureUrl, TrailerUrl, Rating, List&lt;Actor&gt;, List&lt;Comment&gt;, Status, Created By, Created At</li>
<li><i>User:</i> Id, First Name, Last Name, List&lt;Movie&gt;, Email, Password, Status, Created At</li>
<li><i>Actor:</i> Id, First Name, Last Name, Status, Created At</li>
<li><i>Category:</i> Id, Name, Status, Created At</li>
<li><i>Comment:</i> Id, Message, Status, Saved At, Saved By, Is Edited, Movie Id</li>
</ol>
<h3 id="user-features">User Features</h3>
<ul>
<li>Login/Register</li>
<li>Browse movies list by categories</li>
<li>See movie details ( “you may also like” suggestions )</li>
<li>Add to list</li>
<li>Mark as seen</li>
<li>Rate movie</li>
<li>Comment on a movie (type: public/private) (Only the creator/admin can edit or delete)</li>
<li>My seen movies</li>
<li>My playlists</li>
<li>Add movie</li>
<li>Add actors</li>
</ul>
<h3 id="admin-features">Admin Features</h3>
<ul>
<li>Login</li>
<li>Browse movies list by categories</li>
<li>See movie details</li>
<li>Comment on a movie (type: public/private)</li>
<li>Moderate comments (Only the creator/admin can edit or delete)</li>
<li>Add a movie</li>
<li>Approve a movie</li>
<li>Add actor</li>
<li>Approve actor</li>
<li>Manage users (Activate/Deactivate, Create, Edit)</li>
</ul>
</div>
</body>

</html>
