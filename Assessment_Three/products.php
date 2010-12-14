<?php
include './includes/config.inc.php';
include MYSQL;

redirect_invalid_user();
include './includes/form_functions.inc.php';
include './includes/header.php';
include './includes/sidebar.php';

$search_errors = array();
?>
<div id="content" class="column-right">
	<form action="searchrequest.php" method="post" accept-charset="utf-8">
		<p>
			<label for="category"><strong>Category:</strong></label>
			<select name="category">
				<option value="0" selected>Please select:</option>
				<option value="1">Name</option>
				<option value="2">Author</option>
				<option value="3">Topic</option>
			</select>
			<?php create_form_input('search', 'text', $search_errors);?>
			<input type="submit" name="submit_button" value="Search &rArr;" id="submit_button" class="formbutton"/>
		</p>
	</form>
</div>
<?php
include './includes/footer.php';
?>