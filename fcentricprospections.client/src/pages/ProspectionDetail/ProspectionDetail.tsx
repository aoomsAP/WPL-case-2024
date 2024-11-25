import { useParams } from "react-router-dom";
import { useEffect, useContext } from "react";
import { ShopDetailCard } from "../../components/ShopDetailCard/ShopDetailCards";
import { ContactTypeCard } from "../../components/ContactTypeCard/ContactTypeCard";
import { VisitTypeCard } from "../../components/VisitTypeCard/VisitTypeCard";
import { GeneralSituation } from "../../components/GeneralSituationCard/GeneralSituationCard";
import { BrandList } from "../../components/BrandList/BrandList";
import { TextSection } from "../../components/TextSection/TextSection";
import { CompetitorBrandList } from "../../components/CompetitorBrandList/CompetitorBrandList";
import { BrandInterestList } from "../../components/BrandInterestList/BrandInterestList";
import styles from "./ProspectionDetail.module.css";
import { Oval } from 'react-loader-spinner'
import { ShopDetailContext } from "../../contexts/ShopDetailContext";
import { ProspectionDetailContext } from "../../contexts/ProspectionDetailContext";

export const ProspectionDetail = () => {

  const { shopId, prospectionId } = useParams();

  // Contexts

  const {
    setShopId,
    shopDetail
  } = useContext(ShopDetailContext);

  const {
    setProspectionId,
    prospectionDetail,
    contactType,
    visitType,
    brands,
    prospectionBrands,
    prospectionCompetitorBrands,
    prospectionBrandInterests,
  } = useContext(ProspectionDetailContext);

  useEffect(() => {
    if (shopId) {
      setShopId(shopId);
    }
    if (prospectionId) {
      setProspectionId(prospectionId);
    }
  }, [shopId, prospectionId])

  return (
    <main className={styles.main}>
      {
        prospectionDetail &&
        <>
          <h1 className={styles.h1}>
            Prospectie ({new Date(prospectionDetail!.visitDate).toLocaleDateString()})
          </h1>

          {shopDetail && <ShopDetailCard shop={shopDetail} />}

          <section className={styles.contactVisitCard}>
            <div>
              {contactType && prospectionDetail && (
                <ContactTypeCard contactType={contactType} contactPersonName={prospectionDetail.contactName ?? ""} />
              )}

              {visitType && prospectionDetail && <VisitTypeCard visitType={visitType} visitContext={prospectionDetail?.visitContext ?? ""} />}
            </div>
          </section>

          <BrandList prospectionBrands={prospectionBrands} brands={brands} />

          <CompetitorBrandList prospectionCompetitorBrands={prospectionCompetitorBrands} />

          {prospectionDetail && <GeneralSituation detail={prospectionDetail} />}

          <BrandInterestList prospectionBrandInterests={prospectionBrandInterests} />

          <TextSection title="Trends en noden in de markt" text={prospectionDetail?.trends} />
          <TextSection title="Extra opmerkingen en feedback" text={prospectionDetail?.extra} />
        </>
      }
      {!prospectionDetail && <Oval />}
    </main>
  );
};
