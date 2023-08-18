import React, { useState } from "react";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import "../Stylesheet/Add_car.css";
import axios from "axios";
function Update() {
  const [car1, setcar1] = useState([]);

  const getc = (data) => {
    axios.put(`https://localhost:8080/Cars/${car1.id}`,data).then(
      (res) => {
        console.log(res);
      },
      (err) => {}
    );
  };
  function handle(event) {
    alert("updated");
    getc(car1);
    console.log(car1);
  }

  return (
    <div className="Update">
      <h3> Update Car </h3>
      <hr />
      <Form onSubmit={handle} action="">
        <Form.Group className="mb-3" controlId="formBasicEmail">
          <Form.Label>
            <b>Car_id </b>(in capitals AA-00-AA-0000)
          </Form.Label>
          <Form.Control
            type="number" 
            id="id"
            required
            
            onChange={(e) => {
              setcar1({ ...car1, id: e.target.value });
            }}
          />
        </Form.Group>

        <Form.Group className="mb-3" controlId="formBasicEmail">
          <Form.Label>
            <b>Rate per Day</b>
          </Form.Label>
          <Form.Control
            type="number"
            placeholder="in rs"
            id="car_rate"
            required
            min={0}
            onChange={(e) => {
              setcar1({ ...car1, car_rate: e.target.value });
            }}
          />
        </Form.Group>

        <Button variant="primary" type="submit ">
          <b>Update</b>
        </Button>
      </Form>
    </div>
  );
}

export default Update;
