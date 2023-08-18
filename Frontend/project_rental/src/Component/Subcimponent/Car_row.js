const Car_row = (props) => {
  const { id, car_nm, car_brnd, car_no, car_address, car_city, car_status,car_rate } =
    props.item;
  return (
    <tr>
      <td>{id}</td>
      <td>{car_no}</td>
      <td>
        {car_brnd}, {car_nm}
      </td>
      <td>
        {car_address}, {car_city}
      </td>
      <td>{car_status}</td>
      <td>{car_rate}</td>
    </tr>
  );
};
export default Car_row;
