import React, { useState } from 'react'
import { FinanceProps } from '../../Types/Interfaces/Finance/FinanceProps';
import { formatDate, getFinanceTypeName } from '../../Services/UtilityService';
import { FinanceType } from '../../Types/Enum/FinanceType';

const FinanceItem: React.FC<FinanceProps> = ({ finance }) => {
  
  return (
    <>
    {
    finance.financeType === FinanceType.Assets ?  (
      <div id={`finance-${finance.id}`} className="bg-blue-100 rounded-xl mb-4 p-4 shadow-md relative">
      <div className="mb-6">
        <div className="text-xl font-bold text-gray-800 my-2">
           {finance.title}
        </div>
        {
            <h3 className="text-xl text-indigo-400 font-bold">
                {getFinanceTypeName(finance.financeType)}
            </h3>
        }
      </div>
        { finance.amount && 
          <p className="text-gray-800 font-semibold">
              Amount: { finance.amount} zł
          </p>}
        { finance.createrd && 
          <p> 
            Created: {formatDate(finance.createrd)}
          </p>
        }
        { finance.updated &&
        <p>
            Updated: {formatDate(finance.updated)}
            </p>
        }
    </div>

      ) : (
        <div id={`finance-${finance.id}`} className="bg-red-200 rounded-xl mb-4 p-4 shadow-md relative">
        <div className="mb-6">
          <div className="text-xl font-bold text-gray-800 my-2">
             {finance.title}
          </div>
          
       
                <h3 className="text-xl text-red-400 font-bold">
                   {getFinanceTypeName(finance.financeType)}
                </h3>
         
          
        </div>
          { finance.amount && 
            <p className="text-gray-800 font-semibold">
                Amount: { finance.amount} zł
            </p>}
          { finance.createrd && 
            <p> 
              Created: {formatDate(finance.createrd)}
            </p>
          }
          { finance.updated &&
          <p>
              Updated: {formatDate(finance.updated)}
              </p>
          }
      </div>

      )
    }


       
   
    </>
  )
}

export default FinanceItem