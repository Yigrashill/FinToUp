import { ClipLoader } from 'react-spinners';

const override  = {
  display : 'block',
  margin : '10px auto',
  borderWidth: '25px' 
}


interface SpinnerProps {
  loading : boolean;
};

//const JobList: React.FC<JobListProps> = ({isHome}) 

const Spinner : React.FC<SpinnerProps> = ({loading}) => {
  return (
    <ClipLoader 
      color='orange'
      loading = {loading}
      cssOverride={override}
      size={150}
      speedMultiplier={0.47}
    />
  );
};

export default Spinner;