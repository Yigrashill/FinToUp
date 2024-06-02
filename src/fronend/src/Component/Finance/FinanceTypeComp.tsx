import React from 'react'
import { FinanceTypeProps } from '../../Types/Interfaces/Finance/FinanceProps';
import { getFinanceTypeName } from '../../Services/UtilityService';
import { FinanceType } from '../../Types/Enum/FinanceType';


 const FinanceTypeComp: React.FC<FinanceTypeProps> = ({ financeType }) => {

  return (
        <div className="items-center font-sans font-bold uppercase min-w-10  text-gray-200">
          {
            financeType === FinanceType.Assets ? (
              <span className='py-1 bg-green-800'>
                { getFinanceTypeName(financeType) }
              </span>
            ) :(
              <span className='py-1 bg-red-800'>
                { getFinanceTypeName(financeType) }
              </span>
            )
          }
        </div>
  )
}

export default FinanceTypeComp