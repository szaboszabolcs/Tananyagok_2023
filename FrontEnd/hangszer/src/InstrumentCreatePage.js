import axios from "axios";
import { useNavigate } from "react-router-dom";
 
export function InstrumentCreatePage() {
  const navigate = useNavigate();

  return (
    <div className="p-5 content bg-whitesmoke text-center">
      <h2>Új hangszer</h2>
      <form 
        onSubmit={(e) => {
          e.preventDefault();
          (async () => {
            try {
              await axios.post("https://kodbazis.hu/api/instruments", {
                  name: e.target.elements.name.value,
                  price: e.target.elements.price.value,
                  quantity: e.target.elements.quantity.value,
                  imageURL: e.target.elements.imageURL.value,
              }, {withCredentials: true});
              navigate("/");
            } catch (err) {
              console.log(err);
            }
          })();
          
        }}
      >
        <div className="form-group row pb-3">
          <label className="col-sm-3 col-form-label">Név:</label>
          <div className="col-sm-9">
            <input type="text" name="name" className="form-control" />
          </div>
        </div>
        <div className="form-group row pb-3">
          <label className="col-sm-3 col-form-label">Ár:</label>
          <div className="col-sm-9">
            <input type="number" name="price" className="form-control" />
          </div>
        </div>
        <div className="form-group row pb-3">
          <label className="col-sm-3 col-form-label">Darabszám:</label>
          <div className="col-sm-9">
            <input type="number" name="quantity" className="form-control" />
          </div>
        </div>
        <div className="form-group row pb-3">
          <label className="col-sm-3 col-form-label">Kép URL:</label>
          <div className="col-sm-9">
            <input type="text" name="imageURL" className="form-control" />
          </div>
        </div>
        <button type="submit" className="btn btn-success">
          Küldés
        </button>
      </form>
    </div>
  );
}