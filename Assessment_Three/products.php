<?php
include './includes/config.inc.php';
include MYSQL;

redirect_invalid_user();
include './includes/form_functions.inc.php';
include './includes/header.php';
include './includes/sidebar.php';

$result;

if ($_SERVER['REQUEST_METHOD'] == 'POST') {
	$category = $_POST['category'];
	$query = $_POST['search'];
	$result = search_items($query, $category);
}

$search_errors = array();
?>
<div id="content" class="column-right">
	<form action="" method="post" accept-charset="utf-8">
		<p>
			<label for="category"><strong>Category:</strong></label>
			<select name="category" id="category">
				<option value="None" selected>Please select:</option>
				<option value="Title">Title</option>
				<option value="Author">Author</option>
				<option value="Publisher">Publisher</option>
				<option value="Topic">Topic</option>
			</select>
			<?php create_form_input('search', 'text', $search_errors); ?>
			<input type="submit" name="submit_button" value="Search &rArr;" id="submit_button" class="formbutton"/>
		</p>
	</form>
	<?php
			if (isset($result)) {
	?>
	<table>
		<tbody>
			<tr>
				<th>Title</th>
				<th>Subject</th>
				<th>Cost</th>
				<th>Details</th>
			</tr>
			<?php foreach ($result as $value) {
			?>
			<tr>
				<td>
					<?php echo $value->title; ?>
				</td>
				<td>
					<?php echo $value->subject ?>
				</td>
				<td>
					<?php echo $value->cost ?>
				</td>
				<td>
					<?php echo '<a href="productdetails.php?id=' . $value->itemId . '">Details</a>'; ?>
				</td>
			</tr>
			<?php
				}
			?>
		</tbody>
	</table>
	<?php } ?>

</div>
<?php
			include './includes/footer.php';
?>