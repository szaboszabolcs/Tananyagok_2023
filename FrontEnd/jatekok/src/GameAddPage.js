import axios from "axios";
import { useNavigate } from "react-router-dom";

export function GameAddPage() {
    const navigate = useNavigate();


    return (
        <div className="p-5 content bg-whitesmoke text-center">
            <h2>Új játék</h2>
            <form
                onSubmit={(e) => {
                    e.preventDefault();
                    (async () => {
                        try {
                            await axios.post("https://localhost:5001/api/Jatekok", {
                                nev: e.target.elements.name.value,
                                megjeleneseve: e.target.elements.year.value,
                                ar: e.target.elements.price.value,
                                leiras: e.target.elements.description.value,
                                kepUrl: e.target.elements.imageURL.value,
                            });
                            navigate("/")
                        } catch (err) {
                            console.log(err);
                        }
                    })();
                }}
            >
                <div className="form-group row pb-3">
                    <label className="col-sm-3 col-form-label">Név:</label>
                    <div className="col-sm-4">
                        <input type="text" name="name" className="form-control" />
                    </div>
                </div>
                <div className="form-group row pb-3">
                    <label className="col-sm-3 col-form-label">Megjelenés éve:</label>
                    <div className="col-sm-1">
                        <input type="number" name="year" className="form-control" />
                    </div>
                </div>
                <div className="form-group row pb-3">
                    <label className="col-sm-3 col-form-label">Ár:</label>
                    <div className="col-sm-1">
                        <input type="number" name="price" className="form-control" />
                    </div>
                </div>
                <div className="form-group row pb-3">
                    <label className="col-sm-3 col-form-label">Leírás:</label>
                    <div className="col-sm-9">
                        <input type="text" name="description" className="form-control" />
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
    )
}